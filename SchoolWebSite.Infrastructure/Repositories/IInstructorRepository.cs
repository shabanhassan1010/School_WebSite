using SchoolWebSite.Data.Entities;
using SchoolWebSite.Infrastructure.Generics;

namespace SchoolWebSite.Infrastructure.Repositories
{
    public interface IInstructorRepository : IGenericRepositoryAsync<Instructor>
    {
    }
}
