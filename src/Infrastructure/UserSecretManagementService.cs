using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

using Microsoft365_E5_Renew_X.Configuration;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public sealed class UserSecretManagementService
{
    private static readonly JsonTypeInfo<ManagedUserSecretDocument> DocumentTypeInfo =
        ManagedUserSecretJsonSerializerContext.Default.ManagedUserSecretDocument;

    private readonly SemaphoreSlim gate = new(1, 1);
    private readonly FileInfo secretFile;

    public UserSecretManagementService(AppOptions options)
    {
        this.secretFile = options.Runtime.UserSecretFile;
    }

    public async Task<ManagedUserSecretDocument> ReadAsync(CancellationToken cancellationToken = default)
    {
        await this.gate.WaitAsync(cancellationToken);
        try
        {
            return await this.ReadUnsafeAsync(cancellationToken);
        }
        finally
        {
            this.gate.Release();
        }
    }

    public async Task<ManagedUserSecretDocument> SaveAsync(ManagedUserSecretDocument document, CancellationToken cancellationToken = default)
    {
        await this.gate.WaitAsync(cancellationToken);
        try
        {
            var normalized = Normalize(document);
            EnsureDirectory();

            await using var stream = new FileStream(
                this.secretFile.FullName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 16 * 1024,
                useAsync: true);

            await JsonSerializer.SerializeAsync(stream, normalized, DocumentTypeInfo, cancellationToken);
            await stream.FlushAsync(cancellationToken);
            return normalized;
        }
        finally
        {
            this.gate.Release();
        }
    }

    private async Task<ManagedUserSecretDocument> ReadUnsafeAsync(CancellationToken cancellationToken)
    {
        if (!this.secretFile.Exists)
        {
            return new ManagedUserSecretDocument();
        }

        await using var stream = this.secretFile.OpenRead();
        var document = await JsonSerializer.DeserializeAsync(stream, DocumentTypeInfo, cancellationToken);
        return Normalize(document ?? new ManagedUserSecretDocument());
    }

    private void EnsureDirectory()
    {
        if (this.secretFile.Directory is not null && !this.secretFile.Directory.Exists)
        {
            this.secretFile.Directory.Create();
        }
    }

    private static ManagedUserSecretDocument Normalize(ManagedUserSecretDocument document)
    {
        document.Users = document.Users
            .Select(account => new ManagedUserSecretAccount
            {
                Name = account.Name.Trim(),
                TenantId = account.TenantId.Trim(),
                ClientId = account.ClientId.Trim(),
                Secret = NormalizeNullable(account.Secret),
                Certificate = NormalizeNullable(account.Certificate),
                FromTime = NormalizeTime(account.FromTime, isEndTime: false),
                ToTime = NormalizeTime(account.ToTime, isEndTime: true),
                Days = account.Days?.Distinct().Order().ToList()
            })
            .Where(account => !string.IsNullOrWhiteSpace(account.Name) ||
                              !string.IsNullOrWhiteSpace(account.TenantId) ||
                              !string.IsNullOrWhiteSpace(account.ClientId) ||
                              !string.IsNullOrWhiteSpace(account.Secret) ||
                              !string.IsNullOrWhiteSpace(account.Certificate))
            .ToList();

        if (document.Settings is not null)
        {
            document.Settings = new ManagedGlobalSettings
            {
                FromTime = NormalizeTime(document.Settings.FromTime, isEndTime: false),
                ToTime = NormalizeTime(document.Settings.ToTime, isEndTime: true),
                Days = document.Settings.Days?.Distinct().Order().ToList(),
                ApiCallIntervalSeconds = Math.Clamp(document.Settings.ApiCallIntervalSeconds, 1, 3600)
            };
        }

        if (document.Passwords is { Count: 0 })
        {
            document.Passwords = null;
        }

        return document;
    }

    private static string? NormalizeNullable(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    private static string? NormalizeTime(string? value, bool isEndTime)
    {
        string? trimmed = NormalizeNullable(value);
        if (trimmed is null)
        {
            return null;
        }

        if (int.TryParse(trimmed, out int hourOnly))
        {
            if (hourOnly is >= 0 and <= 23)
            {
                return new TimeOnly(hourOnly, 0, 0).ToString("HH:mm:ss");
            }

            if (hourOnly == 24)
            {
                return isEndTime ? "23:59:59" : "00:00:00";
            }
        }

        if (trimmed is "24:00" or "24:00:00")
        {
            return isEndTime ? "23:59:59" : "00:00:00";
        }

        if (TimeOnly.TryParse(trimmed, out TimeOnly parsed))
        {
            return parsed.ToString("HH:mm:ss");
        }

        return trimmed;
    }
}
