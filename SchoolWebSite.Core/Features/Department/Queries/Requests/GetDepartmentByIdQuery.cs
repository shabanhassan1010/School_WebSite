using MediatR;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Department.Queries.Responses;

namespace SchoolWebSite.Core.Features.Department.Queries.Requests
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; } // Id From Department
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
