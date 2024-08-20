using SchoolProject.Data.Entities;

namespace SchoolWebSite.Services.AbstractMethods
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        //public Task<Student> GetStudentByIdToDeleteAsync(int id);
        public Task<string> AddAysnc(Student student);
        public Task<bool> IsNameExsit(String name);
        public Task<bool> IsDepartmentIdExsit(int id);
        public Task<bool> IsNameExsitExcludeSelf(int id);
        public Task<string> EditAysnc(Student student);
        public Task<string> DeleteAysnc(Student student);
    }
}
