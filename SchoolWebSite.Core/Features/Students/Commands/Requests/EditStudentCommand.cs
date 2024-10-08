﻿using MediatR;
using SchoolWebSite.Core.Bases;

namespace SchoolWebSite.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>  // Return<String> the Student has edit Successfully
    {
        public int Id { get; set; }  // Pk
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
