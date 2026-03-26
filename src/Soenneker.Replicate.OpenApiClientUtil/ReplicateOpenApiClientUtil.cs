using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Replicate.HttpClients.Abstract;
using Soenneker.Replicate.OpenApiClientUtil.Abstract;
using Soenneker.Replicate.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Replicate.OpenApiClientUtil;

///<inheritdoc cref="IReplicateOpenApiClientUtil"/>
public sealed class ReplicateOpenApiClientUtil : IReplicateOpenApiClientUtil
{
    private readonly AsyncSingleton<ReplicateOpenApiClient> _client;

    public ReplicateOpenApiClientUtil(IReplicateOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ReplicateOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Replicate:ApiKey");
            string authHeaderValueTemplate = configuration["Replicate:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
