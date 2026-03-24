

using E5Renewer.Models.Modules;
using E5Renewer.Models.Secrets;
using E5Renewer.Models.Statistics;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;

namespace E5Renewer.Models.GraphAPIs;

/// <summary>
/// <see cref="IGraphAPICaller">IGraphAPICaller</see>
/// implementation which calls msgraph apis randomly.
/// </summary>
[Module]
public class RandomGraphAPICaller : BasicModule, IGraphAPICaller
{
    private static readonly string[] UnsupportedApiPrefixes =
    [
        "FilterOperators.",
        "IdentityGovernance.AccessReviews.",
        "IdentityGovernance.TermsOfUse.AgreementAcceptances.",
        "IdentityGovernance.PrivilegedAccess.Group.AssignmentSchedules.",
        "IdentityGovernance.PrivilegedAccess.Group.EligibilitySchedules.",
        "Identity.AuthenticationEventListeners.",
        "Identity.B2xUserFlows.",
        "Reports.ManagedDeviceEnrollment",
        "Security.SubjectRightsRequests.",
    ];

    private static readonly HashSet<string> UnsupportedApiIds =
    [
        "AgreementAcceptances.Get",
        "DeviceManagement.ManagedDevices.Count.Get",
        "DeviceManagement.NotificationMessageTemplates.Count.Get",
        "DeviceManagement.UserExperienceAnalyticsCategories.Get",
        "DeviceManagement.UserExperienceAnalyticsModelScores.Count.Get",
        "DeviceManagement.UserExperienceAnalyticsAppHealthApplicationPerformanceByAppVersionDeviceId.Count.Get",
        "DirectoryRoleTemplates.Count.Get",
        "GroupSettingTemplates.Delta.Get",
        "Invitations.Count.Get",
        "OAuth2PermissionGrants.Get",
        "PermissionGrants.Get",
        "RoleManagement.EntitlementManagement.Get",
        "RoleManagement.EntitlementManagement.ResourceNamespaces.Get",
        "ScopedRoleMemberships.Count.Get",
        "ScopedRoleMemberships.Get",
    ];

    private readonly ILogger<RandomGraphAPICaller> logger;
    private readonly IAPIFunction[] apiFunctions;
    private readonly IStatusManager statusManager;
    private readonly IUserClientProvider clientProvider;
    private readonly IConfiguration configuration;

    /// <summary>Initialize <c>RandomGraphAPICaller</c> with parameters given.</summary>
    /// <param name="logger">The logger to generate log.</param>
    /// <param name="apiFunctions">All known api functions with their id.</param>
    /// <param name="statusManager"><see cref="IStatusManager"/> implementation.</param>
    /// <param name="clientProvider"><see cref="IUserClientProvider"/> implementation.</param>
    /// <param name="configuration">Configuration source for runtime tuning.</param>
    /// <remarks>All parameters should be injected by Asp.Net Core.</remarks>
    public RandomGraphAPICaller(
        ILogger<RandomGraphAPICaller> logger,
        IEnumerable<IAPIFunction> apiFunctions,
        IStatusManager statusManager,
        IUserClientProvider clientProvider,
        IConfiguration configuration
    )
    {
        this.logger = logger;
        IAPIFunction[] allApiFunctions = apiFunctions.ToArray();
        this.apiFunctions = allApiFunctions.Where(ShouldIncludeApi).ToArray();
        this.statusManager = statusManager;
        this.clientProvider = clientProvider;
        this.configuration = configuration;
        int filteredCount = allApiFunctions.Length - this.apiFunctions.Length;
        this.logger.LogInformation(
            "已加载 {AvailableCount} 个可用 Microsoft Graph 接口，已排除 {FilteredCount} 个天然不支持或仍使用旧模板的接口。",
            this.apiFunctions.Length,
            filteredCount
        );
    }

    /// <inheritdoc/>
    public async Task CallNextAPIAsync(User user)
    {
        if (this.apiFunctions.Count() <= 0)
        {
            this.logger.LogError("No {0} is found.", nameof(IAPIFunction));
            return;
        }


        int GetFunctionWeightOfCurrentUser(IAPIFunction function)
        {
            string successAPICallResult = new APICallResult().ToString();
            IEnumerable<string> results = this.statusManager.GetResultsAsync(user.name, function.id).Result;
            if (results.Any(IsUnsupportedResult))
            {
                return 0;
            }

            int successCount = results.Count((item) => item == successAPICallResult);
            return successCount + 1; // let weight greater than zero
        }

        GraphServiceClient client = await this.clientProvider.GetClientForUserAsync(user);
        IAPIFunction[] availableFunctions = this.apiFunctions.Where((function) => GetFunctionWeightOfCurrentUser(function) > 0).ToArray();
        if (availableFunctions.Length == 0)
        {
            availableFunctions = this.apiFunctions;
        }

        IAPIFunction apiFunction = availableFunctions.GetDifferentItemsByWeight(GetFunctionWeightOfCurrentUser, 1).First();
        APICallResult result = await apiFunction.SafeCallAsync(client, user.name);
        await this.statusManager.SetResultAsync(user.name, apiFunction.id, result.ToString());
    }

    /// <inheritdoc/>
    public async Task CalmDownAsync(CancellationToken token, User user)
    {
        if (user.timeToStart == TimeSpan.Zero)
        {
            int seconds = this.configuration.GetValue<int?>("Runtime:GraphApiIntervalSeconds") ?? 1;
            int milliseconds = Math.Clamp(seconds, 1, 3600) * 1000;
            this.logger.LogDebug("{0} is going to sleep for {1} millisecond(s)", user.name, milliseconds);
            await Task.Delay(milliseconds, token);
        }
    }

    private static bool ShouldIncludeApi(IAPIFunction function)
    {
        if (UnsupportedApiIds.Contains(function.id))
        {
            return false;
        }

        return !UnsupportedApiPrefixes.Any(function.id.StartsWith);
    }

    private static bool IsUnsupportedResult(string result)
    {
        return result.Contains("|NoMethodMatchRouteTemplate", StringComparison.Ordinal)
            || result.Contains("|UnsupportedCountRoute", StringComparison.Ordinal)
            || result.Contains("|DirectQueriesNotSupported", StringComparison.Ordinal)
            || result.Contains("|DifferentialQueryNotSupported", StringComparison.Ordinal)
            || result.Contains("|ChangeTrackingNotSupported", StringComparison.Ordinal)
            || result.Contains("|SearchNotSupported", StringComparison.Ordinal)
            || result.Contains("|ProviderNotSupported", StringComparison.Ordinal)
            || result.Contains("|RequestPathNotSupported", StringComparison.Ordinal)
            || result.Contains("|LegacyCpimEndpoint", StringComparison.Ordinal)
            || result.Contains("|LegacySyncfabricEndpoint", StringComparison.Ordinal)
            || result.Contains("|LegacyIdentityGovernanceEndpoint", StringComparison.Ordinal);
    }
}
