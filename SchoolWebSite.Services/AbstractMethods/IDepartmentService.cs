using SchoolProject.Data.Entities;

namespace SchoolWebSite.Services.AbstractMethods
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<Department> GetDepartmentPaginatedById(int id);

    }
}
