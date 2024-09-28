#region 
using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Services.AbstractMethods;
using SchoolWebSite.Services.ImplemtionsForAbstractMethod;
#endregion

namespace SchoolWebSite.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
