using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Generics;

namespace SchoolWebSite.Infrastructure.Repositories
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetAllStudentAsync();
    }
}
