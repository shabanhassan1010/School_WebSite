﻿#region
using MediatR;
using SchoolWebSite.Core.Bases;
#endregion

namespace SchoolWebSite.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
    }
}
