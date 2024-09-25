#region
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Infrastructure.Generics;
using SchoolWebSite.Infrastructure.Repositories;
#endregion

namespace SchoolWebSite.Infrastructure
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructor
        public StudentRepository(ApplictionDBContext dBContext) : base(dBContext) //in GenericRepositoryAsync Constructor
        {
            _students = dBContext.Set<Student>();
        }
        #endregion

        #region Handles Methods
        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _students.Include(x => x.Department).ToListAsync();
        }
        #endregion
    }
}
