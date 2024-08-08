#region
using MediatR;
using SchoolWebSite.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SchoolWebSite.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
    }
}
