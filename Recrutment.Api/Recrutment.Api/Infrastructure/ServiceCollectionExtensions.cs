namespace Recrutment.Api.Infrastructure
{
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// All routes are lowercase (CEO friendly).
        /// </summary>
        public static IServiceCollection AddLowercaseRouting(this IServiceCollection services)
            => services.AddRouting(routing => routing.LowercaseUrls = true);

        /// <summary>
        /// Register all services which are in assembly of IService interface as transient into IoC Container.
        /// </summary>
        /// <param name="services">IoC Container.</param>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                ?.GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name.Equals($"I{t.Name}")))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t,
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }

        /// <summary>
        /// Add AutoMapper in IServiceCollection (DI Container) as Singleton.
        /// </summary>
        /// <param name="services">IServiceCollection (DI Container).</param>
        /// <returns>IServiceCollection (DI Container) with added AutoMapper.</returns>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // Configuration register all mappings found in these assemblies.
            AutoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly());

            services.AddSingleton(AutoMapperConfig.MapperInstance); // Register Service

            return services;
        }
    }
}
