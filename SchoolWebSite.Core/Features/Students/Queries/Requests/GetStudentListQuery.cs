using Azure;
using MediatR;
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Students.Queries.Responses;

namespace SchoolWebSite.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<SchoolWebSite.Core.Bases.Response<List<GetStudentListResponse>>>
    {
    }
}
