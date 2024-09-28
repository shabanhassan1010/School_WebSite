using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Repositories;
using SchoolWebSite.Services.AbstractMethods;

namespace SchoolWebSite.Services.ImplemtionsForAbstractMethod
{
    public class DepartmentService : IDepartmentService
    {
        #region Field
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<Department> GetDepartmentById(int id)
        {
            var GetDeptid = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                .Include(x => x.DepartmentSubjects)
                .Include(x => x.Students)
                .Include(x => x.Instructors)
                .Include(x => x.Instructor).FirstOrDefaultAsync();
            return GetDeptid;
        }
        #endregion
    }
}
