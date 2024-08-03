#region
using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
