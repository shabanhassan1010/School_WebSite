#region
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Department.Queries.Requests;
using SchoolWebSite.Core.Features.Department.Queries.Responses;
using SchoolWebSite.Core.Resourses;
using SchoolWebSite.Services.AbstractMethods;

#endregion
namespace SchoolWebSite.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
                                          IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _stringLocalizer;
        #endregion

        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResourses> stringLocalizer, IDepartmentService departmentService, IMapper mapper) : base(stringLocalizer)
        {
            stringLocalizer = _stringLocalizer;
            _departmentService = departmentService;
            _mapper = mapper;
        }
        #endregion

        async Task<Response<GetDepartmentByIdResponse>> IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>.Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // in Service Layer I will implement this (GetByIdAsync) to include >> ins , sub , deptsub
            var Response = await _departmentService.GetDepartmentById(request.Id);
            // Check if Is not Exist 
            if (Response == null)
                return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResoursesKeys.NotFound]);
            // Mapping
            var mapper = _mapper.Map<GetDepartmentByIdResponse>(Response);
            // Return Response
            return Success(mapper);
        }
    }
}
