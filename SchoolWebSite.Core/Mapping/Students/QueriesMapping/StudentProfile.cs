#region
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
#endregion


namespace SchoolWebSite.Core.Mapping.Students     // The same namespace which is exist in ( StudentProfile : Profile ) class
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Localizable(src.Department.DNameAr, src.Department.DNameEn)))
                            .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Localizable(src.NameAr, src.NameEn)));

            // dest == GetStudentListResponse
            // src == Student
        }
    }
}


