using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Commands.Models;

namespace SchoolWebSite.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
            // I will map on Column DID from Depatment                       // DepartmentId >> From Request
            .ForMember(dest => dest.DID, options => options.MapFrom(src => src.DepartmentId))
            // Ana hna 3amlet mapp 3ashan StudID mawgod with this name on student table ane I send src.Id in My Request
            .ForMember(dest => dest.StudID, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.NameAr, options => options.MapFrom(src => src.NameAr))
            .ForMember(dest => dest.NameEn, options => options.MapFrom(src => src.NameEn));

            // dest(destination) == GetStudentListResponse
            // src(sourse)       == Student
        }
    }
}
