﻿#region
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
#endregion


namespace SchoolWebSite.Core.Mapping.Students     // The same namespace which is exist in ( StudentProfile : Profile ) class
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.DName));
            // dest == GetStudentListResponse
            // src == Student
        }
    }
}


