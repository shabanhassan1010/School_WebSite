#region
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Data.Helper;
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

        public IQueryable<Student> GetStudentQuearable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuery(StudentOrederingEnum Ordering, string serach)
        {
            var quearable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (quearable != null)
            {
                quearable = quearable.Where(x => x.Name.Contains(serach) || x.Address.Contains(serach));
            }
            switch (Ordering)
            {
                case StudentOrederingEnum.StudID:
                    quearable = quearable.OrderBy(x => x.StudID);
                    break;
                case StudentOrederingEnum.Name:
                    quearable = quearable.OrderBy(x => x.Name);
                    break;
                case StudentOrederingEnum.Address:
                    quearable = quearable.OrderBy(x => x.Address);
                    break;
                case StudentOrederingEnum.DepartmentName:
                    quearable = quearable.OrderBy(x => x.Department.DName);
                    break;
                default:
                    quearable = quearable.OrderBy(x => x.StudID);
                    break;
            }
            return quearable;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var StudentId = await _studentRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .Where(x => x.StudID == id).FirstOrDefaultAsync();
            return StudentId;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            var StudentId = await _studentRepository.GetTableNoTracking().Where(x => x.StudID == id).FirstOrDefaultAsync();
            return StudentId;
        }

        //public async Task<Student> GetStudentByIdToDeleteAsync(int id)
        //{
        //    var StudentId = await _studentRepository.GetByIdAsync(id);
        //    return StudentId;
        //}

        public async Task<string> AddAysnc(Student student)
        {
            var isFound = await _studentRepository.GetTableNoTracking().Where(x => x.StudID.Equals(student.StudID)).FirstOrDefaultAsync();
            if (isFound != null) // this ID is Exist
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

        public async Task<bool> IsNameExsitExcludeSelf(int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.StudID.Equals(id)).FirstOrDefaultAsync();
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

        public async Task<bool> IsDepartmentIdExsit(int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id)).FirstOrDefaultAsync();
            if (student == null)
                return false;
            else
                return true;
        }

        public async Task<string> DeleteAysnc(Student student)
        {
            var Transactions = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await Transactions.CommitAsync();
                return "Success";
            }
            catch
            {
                await Transactions.RollbackAsync(); // now he will not save anything in database
                return "Failed";
            }
        }
        #endregion
    }
}
