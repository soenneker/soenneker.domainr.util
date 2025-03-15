using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Domainr.Client.Registrars;
using Soenneker.Domainr.Util.Abstract;

namespace Soenneker.Domainr.Util.Registrars;

/// <summary>
/// A .NET typesafe implementation of Domainr's API
/// </summary>
public static class DomainrUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IDomainrUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDomainrUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDomainrClientUtilAsSingleton().TryAddSingleton<IDomainrUtil, DomainrUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IDomainrUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDomainrUtilAsScoped(this IServiceCollection services)
    {
        services.AddDomainrClientUtilAsScoped().TryAddScoped<IDomainrUtil, DomainrUtil>();

        return services;
    }
}