#region
using AutoMapper;
using MediatR;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Students.Queries.Models;
using SchoolWebSite.Core.Features.Students.Queries.Responses;
using SchoolWebSite.Services.AbstractMethods;
#endregion

namespace SchoolWebSite.Core.Features.Students.Queries.Handlers
{
        public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
        {
            #region Fields
            private readonly IStudentService _studentService;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor
            public StudentHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }
            #endregion

            #region Handles Functions
            public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
            {
                var studentsList = await _studentService.GetStudentListAsync();
                var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentsList);
                return Success(studentListMapper);
            }
            #endregion
        }
}
