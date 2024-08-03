using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSite.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplictionDBContext _applictionDBContext;
        #endregion

        #region Constructor
        public StudentRepository(ApplictionDBContext applictionDBContext)
        {
            _applictionDBContext = applictionDBContext;
        }
        #endregion

        #region Handles Methods
        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _applictionDBContext.students.ToListAsync();
        }
        #endregion
    }
}
