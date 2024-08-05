using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSite.Infrastructure.Repositories
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetAllStudentAsync();
    }
}
