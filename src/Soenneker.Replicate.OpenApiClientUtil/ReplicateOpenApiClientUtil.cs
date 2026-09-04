using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Replicate.HttpClients.Abstract;
using Soenneker.Replicate.OpenApiClientUtil.Abstract;
using Soenneker.Replicate.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Replicate.OpenApiClientUtil;

/// <inheritdoc cref="IReplicateOpenApiClientUtil" />
public sealed class ReplicateOpenApiClientUtil : IReplicateOpenApiClientUtil
{
    private readonly AsyncSingleton<ReplicateOpenApiClient> _client;

    public ReplicateOpenApiClientUtil(IReplicateOpenApiHttpClient httpClientUtil, IConfiguration _)
    {
        _client = new AsyncSingleton<ReplicateOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new ReplicateOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ReplicateOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
