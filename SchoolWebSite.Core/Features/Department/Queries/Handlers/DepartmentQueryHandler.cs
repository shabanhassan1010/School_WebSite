#region
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Department.Queries.Requests;
using SchoolWebSite.Core.Features.Department.Queries.Responses;
using SchoolWebSite.Core.Resourses;
using SchoolWebSite.Core.Wrappers;
using SchoolWebSite.Services.AbstractMethods;
using System.Linq.Expressions;

#endregion

namespace SchoolWebSite.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
                                          IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
                                          IRequestHandler<GetDepartmentPaginatedByIdQuery, Response<GetDepartmentPaginatedByIdRespones>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _stringLocalizer;
        #endregion

        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResourses> stringLocalizer, IDepartmentService departmentService, IStudentService studentService, IMapper mapper) : base(stringLocalizer)
        {
            stringLocalizer = _stringLocalizer;
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handles Functions

        #region  GetDepartmentByIdQuery
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
        #endregion

        #region  GetDepartmentPaginatedByIdQuery
        public async Task<Response<GetDepartmentPaginatedByIdRespones>> Handle(GetDepartmentPaginatedByIdQuery request, CancellationToken cancellationToken)
        {
            // Get the department with pagination
            var response = await _departmentService.GetDepartmentPaginatedById(request.Id);

            // Check if it doesn't exist
            if (response == null)
                return NotFound<GetDepartmentPaginatedByIdRespones>(_stringLocalizer[SharedResoursesKeys.NotFound]);

            // Mapping
            var mapper = _mapper.Map<GetDepartmentPaginatedByIdRespones>(response);

            // Paginated student response
            Expression<Func<Student, StudentResponsePaginated>> expression = e => new StudentResponsePaginated(e.StudID, e.Localizable(e.NameAr, e.NameEn));
            var studentQueryable = _studentService.GetStudentPagintedQuearable(request.Id);

            var paginatedList = await studentQueryable.Select(expression).ToPaginatedListAsync(request.StudentPageSize, request.StudentPageNumber);
            mapper.ListOfStudentResponsePaginated = paginatedList;

            // Return success response
            return Success(mapper);
        }

        #endregion  
        #endregion
    }
}
