using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Replicate.HttpClients.Registrars;
using Soenneker.Replicate.OpenApiClientUtil.Abstract;

namespace Soenneker.Replicate.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class ReplicateOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ReplicateOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddReplicateOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddReplicateOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IReplicateOpenApiClientUtil, ReplicateOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ReplicateOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddReplicateOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddReplicateOpenApiHttpClientAsSingleton()
                .TryAddScoped<IReplicateOpenApiClientUtil, ReplicateOpenApiClientUtil>();

        return services;
    }
}
