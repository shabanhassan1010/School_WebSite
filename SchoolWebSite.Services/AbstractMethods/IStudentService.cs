using SchoolProject.Data.Entities;

namespace SchoolWebSite.Services.AbstractMethods
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(int id);

    }
}
