#region
using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Infrastructure.Repositories;
#endregion

namespace SchoolWebSite.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
