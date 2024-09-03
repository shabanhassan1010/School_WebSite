using MediatR;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
using SchoolWebSite.Core.Wrappers;
using SchoolWebSite.Data.Helper;

namespace SchoolWebSite.Core.Features.Students.Queries.Requests
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentListPaginatedResponse>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public StudentOrederingEnum OrderBy { get; set; }
        public string Search { get; set; } = string.Empty;

    }
}
