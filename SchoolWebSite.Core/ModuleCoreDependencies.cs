using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Services.AbstractMethods;
using SchoolWebSite.Services.ImplemtionsForAbstractMethod;
using System.Reflection;

namespace SchoolWebSite.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Configration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Configration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); return services;
            return services;
        }
    }
}
 