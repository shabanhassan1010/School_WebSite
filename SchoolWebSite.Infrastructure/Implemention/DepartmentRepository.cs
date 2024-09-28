using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Infrastructure.Generics;
using SchoolWebSite.Infrastructure.Repositories;

namespace SchoolWebSite.Infrastructure.Implemention
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private readonly DbSet<Department> _departments;
        #endregion

        #region Constructor
        public DepartmentRepository(ApplictionDBContext dBContext) : base(dBContext) //in GenericRepositoryAsync Constructor
        {
            _departments = dBContext.Set<Department>();
        }
        #endregion
    }
}
