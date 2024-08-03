#region
using MediatR;
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Queries.Models;
using SchoolWebSite.Services.AbstractMethods;
#endregion

namespace SchoolWebSite.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            // Replace this with your actual logic to get students
            var students = await _studentService.GetStudentListAsync();
            return students;
        }
        #endregion              
    }

}
