#region
using MediatR;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
#endregion

namespace SchoolWebSite.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetSingleStudentResponse>>>
    {
        // install MediatR Design pattern
    }
}
