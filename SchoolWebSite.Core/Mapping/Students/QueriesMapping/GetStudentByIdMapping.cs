using Microsoft.Extensions.Options;
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

