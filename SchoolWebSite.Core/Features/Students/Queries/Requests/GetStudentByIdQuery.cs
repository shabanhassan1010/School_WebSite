#region
using MediatR;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
#endregion
namespace SchoolWebSite.Core.Features.Students.Queries.Requests
{
    public class GetStudentByIdQuery :IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
