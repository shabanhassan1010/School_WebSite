#region
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Repositories;
using SchoolWebSite.Services.AbstractMethods;
#endregion

namespace SchoolWebSite.Services.ImplemtionsForAbstractMethod
{
    public class StudentService : IStudentService
    {
        #region Field
        private readonly IStudentRepository _studentRepository;

        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentRepository.GetAllStudentAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var StudentId = await _studentRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .Where(x => x.StudID == id).FirstOrDefaultAsync();
            return StudentId;
        }
        #endregion
    }
}
