using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Replicate.HttpClients.Registrars;
using Soenneker.Replicate.OpenApiClientUtil.Abstract;

namespace Soenneker.Replicate.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Replicate API client.
/// </summary>
public static class ReplicateOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Replicate API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddReplicateOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddReplicateOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IReplicateOpenApiClientUtil, ReplicateOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Replicate API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddReplicateOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddReplicateOpenApiHttpClientAsSingleton()
                .TryAddScoped<IReplicateOpenApiClientUtil, ReplicateOpenApiClientUtil>();

        return services;
    }
}
