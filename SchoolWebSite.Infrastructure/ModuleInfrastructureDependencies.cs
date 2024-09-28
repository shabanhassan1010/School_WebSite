#region
using Microsoft.Extensions.DependencyInjection;
using SchoolWebSite.Infrastructure.Generics;
using SchoolWebSite.Infrastructure.Implemention;
using SchoolWebSite.Infrastructure.Repositories;
#endregion

namespace SchoolWebSite.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
