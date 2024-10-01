using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Department.Queries.Responses;
using SchoolWebSite.Data.Entities;

namespace SchoolWebSite.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetStudentPaginatedByIdMapping()
        {
            CreateMap<Department, GetDepartmentPaginatedByIdRespones>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.DID)) // Id
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Localizable(src.DNameAr, src.DNameEn)))  // Name
                .ForMember(dest => dest.MangerName, options => options.MapFrom(src => src.Instructor.Localizable(src.Instructor.INameEn, src.Instructor.INameAr))) // MangerName 
                .ForMember(dest => dest.ListOfSubjectResponsePaginated, options => options.MapFrom(src => src.DepartmentSubjects)) // ListOfSubjectResponse
                .ForMember(dest => dest.ListOfSInstructorResponsePaginated, options => options.MapFrom(src => src.Instructors)); // ListOfSInstructorResponse

            CreateMap<DepartmetSubject, SubjectResponsePaginated>()
                       .ForMember(dest => dest.Id, options => options.MapFrom(src => src.SubID))
                       .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Subject.Localizable(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            CreateMap<Instructor, InstructorResponsePaginated>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.InsId))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Localizable(src.INameAr, src.INameEn)));

            // dest == GetStudentListResponse
            // src == Department
        }
    }
}