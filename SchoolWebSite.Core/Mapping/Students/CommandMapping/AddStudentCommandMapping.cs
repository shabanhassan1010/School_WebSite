#region
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Commands.Models;
#endregion

namespace SchoolWebSite.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping() // I will use this method in my StudentProfile Constructor
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, options => options.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.NameAr, options => options.MapFrom(src => src.NameAr))
                .ForMember(dest => dest.NameEn, options => options.MapFrom(src => src.NameEn));

            // dest == GetStudentListResponse
            // src == Student
        }
    }
}
