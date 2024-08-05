using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Infrastructure.Generics;
using SchoolWebSite.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSite.Infrastructure
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructor
        public StudentRepository(ApplictionDBContext applictionDBContext):base(applictionDBContext)
        {
            _students = applictionDBContext.Set<Student>();
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
