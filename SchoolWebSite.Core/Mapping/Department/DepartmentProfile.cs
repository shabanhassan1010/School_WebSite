using AutoMapper;

namespace SchoolWebSite.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetStudentByIdMapping();
            GetStudentPaginatedByIdMapping();
        }
    }
}
