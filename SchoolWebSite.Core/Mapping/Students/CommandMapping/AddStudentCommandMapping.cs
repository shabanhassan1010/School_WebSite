#region
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SchoolWebSite.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public  void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, options => options
                .MapFrom(src => src.DepartmentId));
            // dest == GetStudentListResponse
            // src == Student
        }
    }
}
