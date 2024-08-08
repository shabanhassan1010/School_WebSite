#region
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
#endregion

namespace SchoolWebSite.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.DName));
            // dest == GetStudentListResponse
            // src == Student
        }
    }
}

