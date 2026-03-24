using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public sealed class RuntimeHistoryService : IHostedService, IDisposable
{
    private const int MaxHistoryFiles = 20;
    private static readonly string[] UserMarkers = ["for user ", "用户 ", "user=", "user = "];
    private static readonly string[] NoisyCategoryPrefixes =
    [
        "Microsoft.AspNetCore.",
        "Microsoft.Extensions.Http.",
        "System.Net.Http.HttpClient.",
        "Microsoft.Hosting.Lifetime"
    ];
    private readonly ConcurrentQueue<RuntimeHistoryEntry> entries = new();
    private readonly ConcurrentQueue<RuntimeHistoryEntry> pendingEntries = new();
    private readonly SemaphoreSlim flushLock = new(1, 1);
    private readonly int capacity;
    private readonly string logFilePath;
    private Timer? flushTimer;
    private bool disposed;

    public RuntimeHistoryService(string contentRootPath, int capacity = 200)
    {
        this.capacity = Math.Max(50, capacity);
        string logDirectory = Path.Combine(contentRootPath, "runtime", "history");
        Directory.CreateDirectory(logDirectory);
        TrimOldHistoryFiles(logDirectory);
        this.logFilePath = Path.Combine(logDirectory, $"{DateTimeOffset.Now:yyyyMMdd-HHmmss}.log");
    }

    public void Add(string category, string level, string message, Exception? exception = null)
    {
        var entry = new RuntimeHistoryEntry
        {
            Timestamp = DateTimeOffset.Now,
            Category = category,
            Level = level,
            Message = message,
            Exception = exception?.Message,
            Account = ExtractAccount(message),
            Operation = ExtractOperation(category, message),
            Outcome = ExtractOutcome(level, message),
            IsMicrosoftCall = IsMicrosoftCall(category, message),
            IsImportant = IsImportant(category, level, message, exception)
        };

        this.entries.Enqueue(entry);
        this.pendingEntries.Enqueue(entry);
        while (this.entries.Count > this.capacity && this.entries.TryDequeue(out _))
        {
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        this.flushTimer = new Timer(
            _ => _ = FlushPendingEntriesAsync(CancellationToken.None),
            null,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        this.flushTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        await FlushPendingEntriesAsync(cancellationToken);
    }

    public IReadOnlyList<RuntimeHistoryEntry> GetRecent(string? account = null, int limit = 80)
    {
        IEnumerable<RuntimeHistoryEntry> query = this.entries.Where(entry =>
            entry.IsImportant &&
            !IsHiddenFromHistory(entry));
        if (!string.IsNullOrWhiteSpace(account))
        {
            query = query.Where(entry =>
                string.Equals(entry.Account, account, StringComparison.OrdinalIgnoreCase));
        }

        return query
            .Reverse()
            .Take(Math.Max(1, limit))
            .ToArray();
    }

    public RuntimeHealthState EvaluateHealth(TimeSpan window)
    {
        DateTimeOffset cutoff = DateTimeOffset.Now.Subtract(window);
        RuntimeHistoryEntry[] recentResults = this.entries
            .Where(entry =>
                entry.IsMicrosoftCall &&
                entry.Timestamp >= cutoff &&
                (string.Equals(entry.Outcome, "成功", StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(entry.Outcome, "失败", StringComparison.OrdinalIgnoreCase)))
            .ToArray();

        int successCount = recentResults.Count(entry =>
            string.Equals(entry.Outcome, "成功", StringComparison.OrdinalIgnoreCase));
        int failureCount = recentResults.Length - successCount;

        if (successCount > 0)
        {
            return new RuntimeHealthState(
                "正常",
                $"最近 {(int)window.TotalMinutes} 分钟至少有 1 次接口调用成功。",
                successCount,
                failureCount);
        }

        if (failureCount > 0)
        {
            return new RuntimeHealthState(
                "警告",
                $"最近 {(int)window.TotalMinutes} 分钟内共有 {failureCount} 次接口调用失败，暂时没有成功记录。",
                successCount,
                failureCount);
        }

        return new RuntimeHealthState(
            "异常",
            $"最近 {(int)window.TotalMinutes} 分钟没有任何接口成功或失败记录，后台任务可能未运行。",
            successCount,
            failureCount);
    }

    private static bool IsHiddenFromHistory(RuntimeHistoryEntry entry)
    {
        if (entry.Message.Contains("请求开始", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return entry.Message.Contains("已加载", StringComparison.OrdinalIgnoreCase) &&
               entry.Message.Contains("个可用 Microsoft Graph 接口", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsImportant(string category, string level, string message, Exception? exception)
    {
        if (exception is not null)
        {
            return true;
        }

        if (string.Equals(level, "Error", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(level, "Warning", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(level, "Critical", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (IsMicrosoftCall(category, message))
        {
            return true;
        }

        return !NoisyCategoryPrefixes.Any(prefix => category.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
    }

    private static string? ExtractAccount(string message)
    {
        foreach (string marker in UserMarkers)
        {
            int markerIndex = message.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
            if (markerIndex < 0)
            {
                continue;
            }

            string remainder = message[(markerIndex + marker.Length)..].Trim();
            if (string.IsNullOrWhiteSpace(remainder))
            {
                continue;
            }

            string account = remainder
                .Split([' ', ',', ';', ':', '!', '?', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault() ?? "";

            if (!string.IsNullOrWhiteSpace(account))
            {
                return account.Trim().TrimEnd(',', ';');
            }
        }

        return null;
    }

    private static string? ExtractOperation(string category, string message)
    {
        const string apiMarker = "api=";
        int apiIndex = message.IndexOf(apiMarker, StringComparison.OrdinalIgnoreCase);
        if (apiIndex >= 0)
        {
            string remainder = message[(apiIndex + apiMarker.Length)..];
            string operation = remainder
                .Split([',', ' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault() ?? "";

            if (!string.IsNullOrWhiteSpace(operation))
            {
                return operation.Trim();
            }
        }

        const string graphPrefix = "E5Renewer.Models.GraphAPIs.";
        if (category.StartsWith(graphPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return category[graphPrefix.Length..];
        }

        return null;
    }

    private static string? ExtractOutcome(string level, string message)
    {
        if (message.Contains("请求成功", StringComparison.OrdinalIgnoreCase))
        {
            return "成功";
        }

        if (message.Contains("请求失败", StringComparison.OrdinalIgnoreCase))
        {
            return "失败";
        }

        if (message.Contains("请求开始", StringComparison.OrdinalIgnoreCase))
        {
            return "开始";
        }

        if (string.Equals(level, "Error", StringComparison.OrdinalIgnoreCase))
        {
            return "失败";
        }

        return null;
    }

    private static bool IsMicrosoftCall(string category, string message) =>
        category.StartsWith("E5Renewer.Models.GraphAPIs.", StringComparison.OrdinalIgnoreCase) ||
        message.Contains("Microsoft Graph 请求", StringComparison.OrdinalIgnoreCase);

    public void Dispose()
    {
        if (this.disposed)
        {
            return;
        }

        this.disposed = true;
        this.flushTimer?.Dispose();
        this.flushLock.Dispose();
    }

    private async Task FlushPendingEntriesAsync(CancellationToken cancellationToken)
    {
        if (!await this.flushLock.WaitAsync(0, cancellationToken))
        {
            return;
        }

        try
        {
            if (this.pendingEntries.IsEmpty)
            {
                return;
            }

            List<RuntimeHistoryEntry> batch = [];
            while (this.pendingEntries.TryDequeue(out RuntimeHistoryEntry? entry))
            {
                batch.Add(entry);
            }

            if (batch.Count == 0)
            {
                return;
            }

            StringBuilder builder = new();
            foreach (RuntimeHistoryEntry entry in batch)
            {
                builder.AppendLine(FormatEntry(entry));
            }

            await File.AppendAllTextAsync(this.logFilePath, builder.ToString(), new UTF8Encoding(false), cancellationToken);
        }
        finally
        {
            this.flushLock.Release();
        }
    }

    private static string FormatEntry(RuntimeHistoryEntry entry)
    {
        var payload = new
        {
            timestamp = entry.Timestamp,
            category = entry.Category,
            level = entry.Level,
            account = entry.Account,
            operation = entry.Operation,
            outcome = entry.Outcome,
            isMicrosoftCall = entry.IsMicrosoftCall,
            isImportant = entry.IsImportant,
            message = entry.Message,
            exception = entry.Exception
        };

        return JsonSerializer.Serialize(payload);
    }

    private static void TrimOldHistoryFiles(string logDirectory)
    {
        try
        {
            FileInfo[] historyFiles = new DirectoryInfo(logDirectory)
                .EnumerateFiles("*.log", SearchOption.TopDirectoryOnly)
                .OrderByDescending(file => file.Name, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            foreach (FileInfo file in historyFiles.Skip(MaxHistoryFiles))
            {
                file.Delete();
            }
        }
        catch
        {
        }
    }
}

public sealed class RuntimeHistoryEntry
{
    public DateTimeOffset Timestamp { get; set; }

    public string Category { get; set; } = "";

    public string Level { get; set; } = "";

    public string Message { get; set; } = "";

    public string? Exception { get; set; }

    public string? Account { get; set; }

    public string? Operation { get; set; }

    public string? Outcome { get; set; }

    public bool IsMicrosoftCall { get; set; }

    public bool IsImportant { get; set; }
}

public sealed record RuntimeHealthState(
    string Status,
    string Message,
    int SuccessCount,
    int FailureCount);
