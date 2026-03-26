using Soenneker.Replicate.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Replicate.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IReplicateOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<ReplicateOpenApiClient> Get(CancellationToken cancellationToken = default);
}
