﻿#region
using AutoMapper;
using MediatR;
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Students.Queries.Models;
using SchoolWebSite.Core.Features.Students.Queries.Requests;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
using SchoolWebSite.Core.Wrappers;
using SchoolWebSite.Services.AbstractMethods;
using System.Linq.Expressions;
#endregion

namespace SchoolWebSite.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetSingleStudentResponse>>>,
                                                            IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
                                                            IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentListPaginatedResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handles Functions
        public async Task<Response<List<GetSingleStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentsList = await _studentService.GetStudentListAsync();
            var studentListMapper = _mapper.Map<List<GetSingleStudentResponse>>(studentsList);
            return Success(studentListMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetSingleStudentResponse>("Object Not Found");
            var res = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(res);
        }

        public async Task<PaginatedResult<GetStudentListPaginatedResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentListPaginatedResponse>> expression = e => new GetStudentListPaginatedResponse(e.StudID, e.Name, e.Address, e.Department.DName);
            //var querable = _studentService.GetStudentQuearable();
            var FilterQuery = _studentService.FilterStudentPaginatedQuery(request.Search);
            var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedList;
        }
        #endregion
    }
}
