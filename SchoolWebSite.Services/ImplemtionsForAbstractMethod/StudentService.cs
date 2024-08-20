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
            var isFound = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(student.Name)).FirstOrDefaultAsync();
            if (isFound != null)
                return "Exist";
            else
                // Add Student 
                await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExsit(string name)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
            if (student != null) return false;
            return true;
        }

        public async Task<bool> IsNameExsitExcludeSelf(string name, int id)
        {
            // must name and id Exist to edit if name or Id is not fount than I can not edit
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null)
                return false;
            else
                return true;
        }

        public async Task<string> EditAysnc(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }
        #endregion
    }
}
