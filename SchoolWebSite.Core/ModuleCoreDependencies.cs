using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Core.Behaviors;
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
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
