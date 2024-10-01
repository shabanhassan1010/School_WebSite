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
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
