using System.Net;

using Microsoft.AspNetCore.Server.Kestrel.Core;

using Microsoft365_E5_Renew_X.Configuration;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public static class KestrelEndpointConfigurator
{
    public static void Configure(ConfigureWebHostBuilder webHost, AppOptions options)
    {
        var urls = ResolveUrls(options)
            .Where(url => !string.IsNullOrWhiteSpace(url))
            .Select(url => url.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (urls.Length == 0)
        {
            urls = ["http://127.0.0.1:51066"];
        }

        webHost.ConfigureKestrel(serverOptions =>
        {
            foreach (var rawUrl in urls)
            {
                var uri = new Uri(rawUrl, UriKind.Absolute);
                var port = uri.IsDefaultPort
                    ? uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ? 443 : 80
                    : uri.Port;

                serverOptions.Listen(BuildHost(uri.Host), port, listenOptions =>
                {
                    if (uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
                    {
                        ConfigureHttps(listenOptions, options);
                    }
                });
            }
        });
    }

    private static string[] ResolveUrls(AppOptions options)
    {
        var aspNetCoreUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
        if (!string.IsNullOrWhiteSpace(aspNetCoreUrls))
        {
            return aspNetCoreUrls
                .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        var portText = Environment.GetEnvironmentVariable("PORT");
        if (int.TryParse(portText, out var port) && port > 0)
        {
            var host = Environment.GetEnvironmentVariable("HOST");
            if (string.IsNullOrWhiteSpace(host))
            {
                host = "0.0.0.0";
            }

            return [$"http://{host}:{port}"];
        }

        return options.Runtime.Urls
            .Where(url => !string.IsNullOrWhiteSpace(url))
            .Select(url => url.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    private static IPAddress BuildHost(string host) =>
        host switch
        {
            "*" or "+" or "0.0.0.0" => IPAddress.Any,
            "[::]" or "::" => IPAddress.IPv6Any,
            "localhost" => IPAddress.Loopback,
            _ when IPAddress.TryParse(host, out var address) => address,
            _ => throw new InvalidOperationException($"暂不支持的 Kestrel 监听地址：{host}")
        };

    private static void ConfigureHttps(ListenOptions listenOptions, AppOptions options)
    {
        var certificatePath = options.LegacySite.Https.Certificate?.Trim();
        if (string.IsNullOrWhiteSpace(certificatePath))
        {
            throw new InvalidOperationException("HTTPS 已启用，但未配置证书路径。");
        }

        var certificateFile = Path.IsPathRooted(certificatePath)
            ? certificatePath
            : Path.Combine(AppContext.BaseDirectory, certificatePath);

        listenOptions.UseHttps(certificateFile, options.LegacySite.Https.Password);
    }
}
