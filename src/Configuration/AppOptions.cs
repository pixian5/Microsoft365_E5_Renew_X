namespace Microsoft365_E5_Renew_X.Configuration;

public sealed class AppOptions
{
    public RuntimeOptions Runtime { get; init; } = new();

    public LegacySiteOptions LegacySite { get; init; } = new();

    public static AppOptions Bind(IConfiguration configuration, string contentRoot)
    {
        var options = configuration.Get<AppOptions>() ?? new AppOptions();
        options.Runtime.UserSecretFile = NormalizeFile(options.Runtime.UserSecretPath, contentRoot, "Deploy/user-secret.json");
        options.Runtime.TokenFile = NormalizeNullableFile(options.Runtime.TokenFilePath, contentRoot);
        return options;
    }

    private static FileInfo NormalizeFile(string? path, string contentRoot, string fallback)
    {
        var finalPath = string.IsNullOrWhiteSpace(path) ? fallback : path;
        return new FileInfo(Path.IsPathRooted(finalPath) ? finalPath : Path.Combine(contentRoot, finalPath));
    }

    private static FileInfo? NormalizeNullableFile(string? path, string contentRoot)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return null;
        }

        var file = new FileInfo(Path.IsPathRooted(path) ? path : Path.Combine(contentRoot, path));
        return file.Exists ? file : null;
    }
}

public sealed class RuntimeOptions
{
    public string DashboardTitle { get; init; } = "Microsoft365 E5 Renew X Next";
    public string ApiBasePath { get; init; } = "/api";
    public string[] Urls { get; init; } = ["http://127.0.0.1:51066"];
    public string[] AllowedMethods { get; init; } = ["GET", "POST"];
    public uint AllowedMaxAgeSeconds { get; init; } = 30;
    public string UserSecretPath { get; init; } = "Deploy/user-secret.json";
    public string? TokenFilePath { get; init; } = "Deploy/token.txt";
    public FileInfo UserSecretFile { get; set; } = new("Deploy/user-secret.json");
    public FileInfo? TokenFile { get; set; } = new("Deploy/token.txt");
}

public sealed class LegacySiteOptions
{
    public ServiceOptions Service { get; init; } = new();
    public HttpsOptions Https { get; init; } = new();
    public ShareSiteOptions ShareSite { get; init; } = new();
}

public sealed class ServiceOptions
{
    public int Port { get; init; } = 51066;
    public string LoginPassword { get; init; } = "请修改管理员密码";
    public bool CoreMultiThread { get; init; } = true;
    public IcpOptions ICP { get; init; } = new();
    public CdnOptions CDN { get; init; } = new();
}

public sealed class IcpOptions
{
    public string Text { get; init; } = "";
    public string Link { get; init; } = "https://beian.miit.gov.cn";
}

public sealed class CdnOptions
{
    public string CSS { get; init; } = "https://cdn.staticfile.org/bootstrap/5.1.3/css/bootstrap.min.css";
    public string JS { get; init; } = "https://cdn.staticfile.org/bootstrap/5.1.3/js/bootstrap.bundle.min.js";
}

public sealed class HttpsOptions
{
    public bool Enable { get; init; }
    public int Port { get; init; } = 1443;
    public string Certificate { get; init; } = "";
    public string Password { get; init; } = "";
}

public sealed class ShareSiteOptions
{
    public bool Enable { get; init; }
    public SmtpOptions SMTP { get; init; } = new();
    public OAuthOptions OAuth { get; init; } = new();
    public SiteSystemOptions System { get; init; } = new();
}

public sealed class SmtpOptions
{
    public string Email { get; init; } = "";
    public string Password { get; init; } = "";
    public string Host { get; init; } = "";
    public int Port { get; init; } = 587;
    public bool EnableSSL { get; init; } = true;
}

public sealed class OAuthOptions
{
    public ProviderOptions Microsoft { get; init; } = new();
    public ProviderOptions Github { get; init; } = new();
}

public sealed class ProviderOptions
{
    public bool Enable { get; init; }
    public string ClientId { get; init; } = "";
    public string ClientSecret { get; init; } = "";
}

public sealed class SiteSystemOptions
{
    public bool AllowRegister { get; init; }
    public string Notice { get; init; } = "";
    public string Master { get; init; } = "";
    public string MasterLink { get; init; } = "";
    public int DefaultQuota { get; init; } = 1;
    public int AutoSpecialPardonInterval { get; init; } = 30;
}
