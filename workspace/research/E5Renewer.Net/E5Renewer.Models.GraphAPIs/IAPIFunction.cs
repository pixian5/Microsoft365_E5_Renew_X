using E5Renewer.Models.Modules;

using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Models.ODataErrors;

namespace E5Renewer.Models.GraphAPIs;

/// <summary>The api interface of msgraph apis implementations.</summary>
public interface IAPIFunction : IModule
{
    /// <value>The id of api.</value>
    public string id { get; }

    /// <value>The logger of api.</value>
    public ILogger logger { get; }

    /// <summary>Call the api implementation.</summary>
    /// <param name="client">The <see cref="GraphServiceClient"/> to user.</param>
    /// <remarks>
    /// Do <b>NOT</b> use this directly,
    /// use <see cref="SafeCallAsync(GraphServiceClient, string)"/> instead.
    /// </remarks>
    public Task<object?> CallAsync(GraphServiceClient client);

    /// <summary>Cal the api implementation safely.</summary>
    /// <param name="client">The <see cref="GraphServiceClient"/> to user.</param>
    /// <param name="user">The name of user</param>
    /// <remarks>Errors will be handed correctly here.</remarks>
    internal async Task<APICallResult> SafeCallAsync(GraphServiceClient client, string user)
    {
        static string BuildFailureToken(string code, string? message)
        {
            string normalizedMessage = message ?? string.Empty;
            string? reason = normalizedMessage switch
            {
                _ when normalizedMessage.Contains("No method match route template", StringComparison.OrdinalIgnoreCase) => "NoMethodMatchRouteTemplate",
                _ when normalizedMessage.Contains("singleton/navigation/$count", StringComparison.OrdinalIgnoreCase) => "UnsupportedCountRoute",
                _ when normalizedMessage.Contains("Direct queries to this resource type are not supported", StringComparison.OrdinalIgnoreCase) => "DirectQueriesNotSupported",
                _ when normalizedMessage.Contains("Differential query is not supported", StringComparison.OrdinalIgnoreCase) => "DifferentialQueryNotSupported",
                _ when normalizedMessage.Contains("Change tracking is not supported", StringComparison.OrdinalIgnoreCase) => "ChangeTrackingNotSupported",
                _ when normalizedMessage.Contains("Searches against this resource are not supported", StringComparison.OrdinalIgnoreCase) => "SearchNotSupported",
                _ when normalizedMessage.Contains("ProviderNotSupported", StringComparison.OrdinalIgnoreCase) => "ProviderNotSupported",
                _ when normalizedMessage.Contains("Request path is not supported", StringComparison.OrdinalIgnoreCase) => "RequestPathNotSupported",
                _ when normalizedMessage.Contains("cpim.windows.net", StringComparison.OrdinalIgnoreCase) => "LegacyCpimEndpoint",
                _ when normalizedMessage.Contains("syncfabric.windowsazure.com", StringComparison.OrdinalIgnoreCase) => "LegacySyncfabricEndpoint",
                _ when normalizedMessage.Contains("identitygovernance.azure.com", StringComparison.OrdinalIgnoreCase) => "LegacyIdentityGovernanceEndpoint",
                _ => null,
            };

            return string.IsNullOrWhiteSpace(reason) ? code : $"{code}|{reason}";
        }

        object? resultRaw;
        this.logger.LogInformation("Microsoft Graph 请求开始: user={0}, api={1}", user, this.id);
        try
        {
            resultRaw = await this.CallAsync(client);
            this.logger.LogDebug("{0} is {1}", nameof(resultRaw), resultRaw);
            string resultType = resultRaw?.GetType().Name ?? "null";
            this.logger.LogInformation("Microsoft Graph 请求成功: user={0}, api={1}, status=200, code=OK, resultType={2}", user, this.id, resultType);
            return new(rawResult: resultRaw);
        }
        catch (ODataError oe)
        {
            int statusCode = oe.ResponseStatusCode;
            string code = oe.Error?.Code ?? "ERROR";
            this.logger.LogError("Microsoft Graph 请求失败: user={0}, api={1}, status={2}, code={3}, message={4}", user, this.id, statusCode, code, oe.Message);
            return new(
                statusCode,
                BuildFailureToken(code, oe.Message)
            );
        }
        catch (Exception ex)
        {
            this.logger.LogError("Microsoft Graph 请求失败: user={0}, api={1}, status=-1, code=ERROR, message={2}", user, this.id, ex.Message);
            return APICallResult.errorResult;
        }
    }
}
