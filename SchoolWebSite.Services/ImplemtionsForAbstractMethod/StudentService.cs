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

        public async Task<string> AddAysnc(Student student)
        {
            var isFound = await _studentRepository.GetTableNoTracking().Where(x => x.Name == student.Name).FirstOrDefaultAsync();
            if (isFound != null)
                return "Exisrt";
            else
                await _studentRepository.AddAsync(student);
                return "Sucess";
        }
        #endregion
    }
}
