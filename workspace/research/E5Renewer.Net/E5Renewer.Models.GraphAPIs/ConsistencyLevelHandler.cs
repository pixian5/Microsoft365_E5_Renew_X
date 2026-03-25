using System.Net.Http;

namespace E5Renewer.Models.GraphAPIs;

/// <summary>
/// Adds ConsistencyLevel:eventual to Graph requests so advanced queries like /$count
/// can succeed without every API module setting the header individually.
/// </summary>
public sealed class ConsistencyLevelHandler : DelegatingHandler
{
    private const string HeaderName = "ConsistencyLevel";
    private const string HeaderValue = "eventual";

    /// <inheritdoc />
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!request.Headers.Contains(HeaderName))
        {
            request.Headers.TryAddWithoutValidation(HeaderName, HeaderValue);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
