using MediatR;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Department.Queries.Responses;

namespace SchoolWebSite.Core.Features.Department.Queries.Requests
{
    public class GetDepartmentPaginatedByIdQuery : IRequest<Response<GetDepartmentPaginatedByIdRespones>>
    {
        public int Id { get; set; }
        public int StudentPageSize { get; set; }
        public int StudentPageNumber { get; set; }
    }
}
