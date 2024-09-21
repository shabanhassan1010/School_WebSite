﻿using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Commands.Models;

namespace SchoolWebSite.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
            .ForMember(dest => dest.DID, options => options.MapFrom(src => src.DepartmentId))
            .ForMember(dest => dest.StudID, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.NameAr, options => options.MapFrom(src => src.NameAr))
            .ForMember(dest => dest.NameEn, options => options.MapFrom(src => src.NameEn));

            // dest(destination) == GetStudentListResponse
            // src(sourse)       == Student
        }
    }
}
