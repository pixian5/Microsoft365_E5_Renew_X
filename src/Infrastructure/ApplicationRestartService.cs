using System.Diagnostics;
using System.Text;

using Microsoft365_E5_Renew_X.Configuration;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public sealed class ApplicationRestartService
{
    private const string RestartJobLabel = "com.pixian5.microsoft365-e5-renew-x.restart";

    private readonly AppOptions options;
    private readonly IWebHostEnvironment environment;
    private readonly IHostApplicationLifetime applicationLifetime;

    public ApplicationRestartService(
        AppOptions options,
        IWebHostEnvironment environment,
        IHostApplicationLifetime applicationLifetime)
    {
        this.options = options;
        this.environment = environment;
        this.applicationLifetime = applicationLifetime;
    }

    public RestartRequestResult Restart()
    {
        string shellCommand = BuildRestartShellCommand();
        AppendRestartLog($"收到重启请求。processPath={Environment.ProcessPath}, cwd={this.environment.ContentRootPath}");

        RestartRequestResult result = StartDetached(shellCommand);
        if (!result.Success)
        {
            AppendRestartLog($"重启提交失败，旧实例将继续运行。方式={result.Method}，原因={result.Message}");
            return result;
        }

        AppendRestartLog($"重启提交成功。方式={result.Method}，旧实例将在 500ms 后停止。");
        _ = Task.Run(async () =>
        {
            await Task.Delay(500);
            this.applicationLifetime.StopApplication();
        });

        return result;
    }

    private string BuildRestartShellCommand()
    {
        string processPath = Environment.ProcessPath ?? "dotnet";
        string[] args = Environment.GetCommandLineArgs();
        string logPath = GetRestartLogPath();
        int listenPort = ResolvePrimaryPort();

        Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);

        List<string> commandParts =
        [
            "sleep 2",
            "&&",
            "cd",
            Quote(this.environment.ContentRootPath),
            "&&",
            "printf",
            Quote($"[{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss.fff zzz}] 新实例启动命令开始执行。\\n"),
            ">>",
            Quote(logPath),
            "&&",
            "while",
            "/usr/sbin/lsof",
            $"-nP -iTCP:{listenPort} -sTCP:LISTEN >/dev/null 2>&1",
            ";",
            "do",
            "printf",
            Quote($"[{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss.fff zzz}] 检测到端口 {listenPort} 仍被占用，等待旧实例退出。\\n"),
            ">>",
            Quote(logPath),
            ";",
            "sleep 0.2",
            ";",
            "done",
            "&&",
            "env"
        ];

        string? dotnetRoot = Environment.GetEnvironmentVariable("DOTNET_ROOT");
        if (!string.IsNullOrWhiteSpace(dotnetRoot))
        {
            commandParts.Add($"DOTNET_ROOT={Quote(dotnetRoot)}");
        }

        string currentPath = Environment.GetEnvironmentVariable("PATH") ?? "";
        if (!string.IsNullOrWhiteSpace(currentPath))
        {
            commandParts.Add($"PATH={Quote(currentPath)}");
        }

        if (args.Length > 0 && args[0].EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
        {
            commandParts.Add(Quote(processPath));
            commandParts.Add(Quote(args[0]));
            foreach (string arg in args.Skip(1))
            {
                commandParts.Add(Quote(arg));
            }
        }
        else
        {
            commandParts.Add(Quote(args.FirstOrDefault() ?? processPath));
            foreach (string arg in args.Skip(1))
            {
                commandParts.Add(Quote(arg));
            }
        }

        commandParts.Add($"</dev/null >> {Quote(logPath)} 2>&1");
        return string.Join(" ", commandParts);
    }

    private RestartRequestResult StartDetached(string shellCommand)
    {
        if (OperatingSystem.IsMacOS())
        {
            RestartRequestResult nohupResult = StartWithNohup(shellCommand);
            if (nohupResult.Success)
            {
                return nohupResult;
            }

            AppendRestartLog($"nohup 启动失败，准备回退到 LaunchAgent。原因={nohupResult.Message}");
            return StartWithLaunchAgent(shellCommand);
        }

        return StartWithNohup(shellCommand);
    }

    private RestartRequestResult StartWithLaunchAgent(string shellCommand)
    {
        int uid = GetCurrentUserId();
        if (uid <= 0)
        {
            return RestartRequestResult.FailureResult("launchctl-bootstrap", "无法获取当前用户 uid。");
        }

        string domain = $"gui/{uid}";
        string plistPath = GetRestartPlistPath();
        string logPath = GetRestartLogPath();
        Directory.CreateDirectory(Path.GetDirectoryName(plistPath)!);
        Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);

        TryUnloadLaunchAgent(domain, plistPath);
        WriteLaunchAgentPlist(plistPath, shellCommand, logPath);

        var bootstrapInfo = new ProcessStartInfo
        {
            FileName = "/bin/launchctl",
            WorkingDirectory = this.environment.ContentRootPath,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        bootstrapInfo.ArgumentList.Add("bootstrap");
        bootstrapInfo.ArgumentList.Add(domain);
        bootstrapInfo.ArgumentList.Add(plistPath);

        RestartRequestResult bootstrapResult = RunAndCapture(bootstrapInfo, "launchctl-bootstrap");
        var kickstartInfo = new ProcessStartInfo
        {
            FileName = "/bin/launchctl",
            WorkingDirectory = this.environment.ContentRootPath,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        kickstartInfo.ArgumentList.Add("kickstart");
        kickstartInfo.ArgumentList.Add("-k");
        kickstartInfo.ArgumentList.Add($"{domain}/{RestartJobLabel}");

        if (bootstrapResult.Success)
        {
            return RunAndCapture(kickstartInfo, "launchctl-kickstart");
        }

        AppendRestartLog($"launchctl bootstrap 未成功，尝试直接 kickstart 已存在服务。原因={bootstrapResult.Message}");
        RestartRequestResult kickstartResult = RunAndCapture(kickstartInfo, "launchctl-kickstart-after-bootstrap-failure");
        if (kickstartResult.Success)
        {
            return kickstartResult;
        }

        return bootstrapResult;
    }

    private RestartRequestResult StartWithNohup(string shellCommand)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "/bin/zsh",
            WorkingDirectory = this.environment.ContentRootPath,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        startInfo.ArgumentList.Add("-lc");
        startInfo.ArgumentList.Add($"nohup /bin/zsh -lc {Quote(shellCommand)} >/dev/null 2>&1 &!");

        return RunAndCapture(startInfo, "nohup");
    }

    private RestartRequestResult RunAndCapture(ProcessStartInfo startInfo, string method)
    {
        try
        {
            using Process? process = Process.Start(startInfo);
            if (process is null)
            {
                return RestartRequestResult.FailureResult(method, "未能启动子进程。");
            }

            process.WaitForExit(5000);
            string stdout = process.StandardOutput.ReadToEnd().Trim();
            string stderr = process.StandardError.ReadToEnd().Trim();

            if (process.ExitCode == 0)
            {
                AppendRestartLog($"{method} 提交成功。stdout={SafeText(stdout)}, stderr={SafeText(stderr)}");
                return RestartRequestResult.SuccessResult(method, "新实例已提交。");
            }

            AppendRestartLog($"{method} 提交失败。exitCode={process.ExitCode}, stdout={SafeText(stdout)}, stderr={SafeText(stderr)}");
            return RestartRequestResult.FailureResult(method, $"退出码 {process.ExitCode}。");
        }
        catch (Exception ex)
        {
            AppendRestartLog($"{method} 提交抛出异常。{ex.GetType().Name}: {ex.Message}");
            return RestartRequestResult.FailureResult(method, ex.Message);
        }
    }

    private int GetCurrentUserId()
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "/usr/bin/id",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            startInfo.ArgumentList.Add("-u");
            using Process? process = Process.Start(startInfo);
            if (process is null)
            {
                return -1;
            }

            process.WaitForExit(2000);
            string output = process.StandardOutput.ReadToEnd().Trim();
            return int.TryParse(output, out int uid) ? uid : -1;
        }
        catch
        {
            return -1;
        }
    }

    private void TryUnloadLaunchAgent(string domain, string plistPath)
    {
        TryRunBestEffortLaunchctl("bootout-path", domain, plistPath);
        TryRunBestEffortLaunchctl("remove-label", "remove", RestartJobLabel);
        TryRunBestEffortLaunchctl("bootout-label", $"{domain}/{RestartJobLabel}");
    }

    private void TryRunBestEffortLaunchctl(string mode, params string[] args)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "/bin/launchctl",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            switch (mode)
            {
                case "bootout-path":
                    startInfo.ArgumentList.Add("bootout");
                    startInfo.ArgumentList.Add(args[0]);
                    startInfo.ArgumentList.Add(args[1]);
                    break;
                case "remove-label":
                    startInfo.ArgumentList.Add("remove");
                    startInfo.ArgumentList.Add(args[1]);
                    break;
                case "bootout-label":
                    startInfo.ArgumentList.Add("bootout");
                    startInfo.ArgumentList.Add(args[0]);
                    break;
            }

            using Process? process = Process.Start(startInfo);
            if (process is null)
            {
                return;
            }

            process.WaitForExit(2000);
            string stdout = process.StandardOutput.ReadToEnd().Trim();
            string stderr = process.StandardError.ReadToEnd().Trim();
            AppendRestartLog($"launchctl {mode} exitCode={process.ExitCode}, stdout={SafeText(stdout)}, stderr={SafeText(stderr)}");
        }
        catch (Exception ex)
        {
            AppendRestartLog($"launchctl {mode} 忽略异常。{ex.GetType().Name}: {ex.Message}");
        }
    }

    private void WriteLaunchAgentPlist(string plistPath, string shellCommand, string logPath)
    {
        string escapedShellCommand = EscapeXml(shellCommand);
        string escapedWorkingDirectory = EscapeXml(this.environment.ContentRootPath);
        string escapedLogPath = EscapeXml(logPath);
        string escapedLabel = EscapeXml(RestartJobLabel);

        string plist = $$"""
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
  <key>Label</key>
  <string>{{escapedLabel}}</string>
  <key>ProgramArguments</key>
  <array>
    <string>/bin/zsh</string>
    <string>-lc</string>
    <string>{{escapedShellCommand}}</string>
  </array>
  <key>WorkingDirectory</key>
  <string>{{escapedWorkingDirectory}}</string>
  <key>RunAtLoad</key>
  <true/>
  <key>KeepAlive</key>
  <false/>
  <key>StandardOutPath</key>
  <string>{{escapedLogPath}}</string>
  <key>StandardErrorPath</key>
  <string>{{escapedLogPath}}</string>
</dict>
</plist>
""";

        File.WriteAllText(plistPath, plist, new UTF8Encoding(false));
        AppendRestartLog($"已写入 LaunchAgent plist: {plistPath}");
    }

    private void AppendRestartLog(string message)
    {
        string logPath = GetRestartLogPath();
        Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);
        string line = $"[{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss.fff zzz}] {message}{Environment.NewLine}";
        File.AppendAllText(logPath, line, new UTF8Encoding(false));
    }

    private string GetRestartLogPath() =>
        Path.Combine(this.environment.ContentRootPath, "runtime", "restart.log");

    private string GetRestartPlistPath() =>
        Path.Combine(this.environment.ContentRootPath, "runtime", $"{RestartJobLabel}.plist");

    private int ResolvePrimaryPort()
    {
        string? firstUrl = this.options.Runtime.Urls
            .FirstOrDefault(url => !string.IsNullOrWhiteSpace(url));
        if (!string.IsNullOrWhiteSpace(firstUrl) &&
            Uri.TryCreate(firstUrl, UriKind.Absolute, out Uri? uri))
        {
            if (!uri.IsDefaultPort)
            {
                return uri.Port;
            }

            return uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ? 443 : 80;
        }

        return this.options.LegacySite.Service.Port;
    }

    private static string SafeText(string value) =>
        string.IsNullOrWhiteSpace(value) ? "<empty>" : value.Replace(Environment.NewLine, " | ");

    private static string EscapeXml(string value) =>
        value
            .Replace("&", "&amp;", StringComparison.Ordinal)
            .Replace("<", "&lt;", StringComparison.Ordinal)
            .Replace(">", "&gt;", StringComparison.Ordinal)
            .Replace("\"", "&quot;", StringComparison.Ordinal)
            .Replace("'", "&apos;", StringComparison.Ordinal);

    private static string Quote(string value) =>
        "'" + value.Replace("'", "'\"'\"'") + "'";
}

public sealed record RestartRequestResult(bool Success, string Method, string Message)
{
    public static RestartRequestResult SuccessResult(string method, string message) => new(true, method, message);

    public static RestartRequestResult FailureResult(string method, string message) => new(false, method, message);
}
