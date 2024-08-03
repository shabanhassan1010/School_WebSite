using MediatR;
using SchoolProject.Data.Entities;

namespace SchoolWebSite.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<List<Student>>

    {
    }
}
