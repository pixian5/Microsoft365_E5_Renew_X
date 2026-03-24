using System.Text.Json;
using System.Text.Json.Nodes;

using Microsoft365_E5_Renew_X.Configuration;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public sealed class DashboardSettingsService
{
    private const int DefaultApiCallIntervalSeconds = 1;
    private const int DefaultFrontendRefreshSeconds = 5;

    private readonly FileInfo appSettingsFile;
    private readonly SemaphoreSlim gate = new(1, 1);

    public DashboardSettingsService(IWebHostEnvironment environment)
    {
        this.appSettingsFile = new FileInfo(Path.Combine(environment.ContentRootPath, "appsettings.json"));
    }

    public async Task<int> GetApiCallIntervalSecondsAsync(CancellationToken cancellationToken = default)
    {
        await this.gate.WaitAsync(cancellationToken);
        try
        {
            JsonObject root = await ReadRootAsync(cancellationToken);
            JsonObject runtime = root["Runtime"] as JsonObject ?? new JsonObject();
            int? value = runtime["GraphApiIntervalSeconds"]?.GetValue<int>();
            return value is >= 1 and <= 3600 ? value.Value : DefaultApiCallIntervalSeconds;
        }
        finally
        {
            this.gate.Release();
        }
    }

    public async Task<int> SaveApiCallIntervalSecondsAsync(int seconds, CancellationToken cancellationToken = default)
    {
        int normalized = Math.Clamp(seconds, 1, 3600);

        await this.gate.WaitAsync(cancellationToken);
        try
        {
            JsonObject root = await ReadRootAsync(cancellationToken);
            JsonObject runtime = root["Runtime"] as JsonObject ?? new JsonObject();
            runtime["GraphApiIntervalSeconds"] = normalized;
            root["Runtime"] = runtime;

            EnsureDirectory();
            await File.WriteAllTextAsync(
                this.appSettingsFile.FullName,
                root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }),
                cancellationToken);

            return normalized;
        }
        finally
        {
            this.gate.Release();
        }
    }

    public async Task<int> GetFrontendRefreshSecondsAsync(CancellationToken cancellationToken = default)
    {
        await this.gate.WaitAsync(cancellationToken);
        try
        {
            JsonObject root = await ReadRootAsync(cancellationToken);
            JsonObject runtime = root["Runtime"] as JsonObject ?? new JsonObject();
            int? value = runtime["DashboardRefreshSeconds"]?.GetValue<int>();
            return value is >= 1 and <= 3600 ? value.Value : DefaultFrontendRefreshSeconds;
        }
        finally
        {
            this.gate.Release();
        }
    }

    public async Task<int> SaveFrontendRefreshSecondsAsync(int seconds, CancellationToken cancellationToken = default)
    {
        int normalized = Math.Clamp(seconds, 1, 3600);

        await this.gate.WaitAsync(cancellationToken);
        try
        {
            JsonObject root = await ReadRootAsync(cancellationToken);
            JsonObject runtime = root["Runtime"] as JsonObject ?? new JsonObject();
            runtime["DashboardRefreshSeconds"] = normalized;
            root["Runtime"] = runtime;

            EnsureDirectory();
            await File.WriteAllTextAsync(
                this.appSettingsFile.FullName,
                root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }),
                cancellationToken);

            return normalized;
        }
        finally
        {
            this.gate.Release();
        }
    }

    private async Task<JsonObject> ReadRootAsync(CancellationToken cancellationToken)
    {
        if (!this.appSettingsFile.Exists)
        {
            return new JsonObject();
        }

        string content = await File.ReadAllTextAsync(this.appSettingsFile.FullName, cancellationToken);
        if (string.IsNullOrWhiteSpace(content))
        {
            return new JsonObject();
        }

        return JsonNode.Parse(content) as JsonObject ?? new JsonObject();
    }

    private void EnsureDirectory()
    {
        if (this.appSettingsFile.Directory is not null && !this.appSettingsFile.Directory.Exists)
        {
            this.appSettingsFile.Directory.Create();
        }
    }
}
