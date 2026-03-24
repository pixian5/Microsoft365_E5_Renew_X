using System.Text.Json.Serialization;

namespace Microsoft365_E5_Renew_X.Configuration;

public sealed class ManagedUserSecretDocument
{
    public List<ManagedUserSecretAccount> Users { get; set; } = [];

    public Dictionary<string, string>? Passwords { get; set; }

    public ManagedGlobalSettings? Settings { get; set; }
}

public sealed class ManagedUserSecretDashboardResponse
{
    public List<ManagedUserSecretAccount> Users { get; set; } = [];

    public Dictionary<string, string>? Passwords { get; set; }

    public ManagedGlobalSettings? Settings { get; set; }

    public bool RestartRequired { get; set; }

    public string UserSecretFile { get; set; } = "";
}

public sealed class ManagedUserSecretSaveResponse
{
    public string Message { get; set; } = "";

    public bool RestartRequired { get; set; }

    public List<ManagedUserSecretAccount> Users { get; set; } = [];

    public ManagedGlobalSettings? Settings { get; set; }

    public string UserSecretFile { get; set; } = "";
}

public sealed class ManagedGlobalSettings
{
    public string? FromTime { get; set; }

    public string? ToTime { get; set; }

    public List<int>? Days { get; set; }

    public int ApiCallIntervalSeconds { get; set; } = 1;

    public int FrontendRefreshSeconds { get; set; } = 5;
}

public sealed class ManagedUserSecretAccount
{
    public string Name { get; set; } = "";

    public string TenantId { get; set; } = "";

    public string ClientId { get; set; } = "";

    public string? Secret { get; set; }

    public string? Certificate { get; set; }

    public string? FromTime { get; set; }

    public string? ToTime { get; set; }

    public List<int>? Days { get; set; }

    public int SuccessCount { get; set; }

    public int FailureCount { get; set; }

    public bool IsStopped { get; set; }
}

[JsonSerializable(typeof(ManagedUserSecretDocument))]
[JsonSerializable(typeof(ManagedUserSecretDashboardResponse))]
[JsonSerializable(typeof(ManagedUserSecretSaveResponse))]
[JsonSerializable(typeof(ManagedGlobalSettings))]
[JsonSerializable(typeof(ManagedStopRequest))]
[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
)]
internal partial class ManagedUserSecretJsonSerializerContext : JsonSerializerContext
{
}
