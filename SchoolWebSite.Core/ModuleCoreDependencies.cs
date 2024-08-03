using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Services.AbstractMethods;
using SchoolWebSite.Services.ImplemtionsForAbstractMethod;

namespace SchoolWebSite.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}
