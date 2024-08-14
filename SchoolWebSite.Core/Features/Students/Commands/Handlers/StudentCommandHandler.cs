#region
using AutoMapper;
using MediatR;
using SchoolProject.Data.Entities;
using SchoolWebSite.Core.Bases;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Services.AbstractMethods;
#endregion

namespace SchoolWebSite.Core.Features.Students.Commands.Handlers
{                                                      // IRequestHandler>> take Request and Return Response
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService , IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handles functions 
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var ResponseFromStudentMapper = _mapper.Map<Student>(request);
            var res = await _studentService.AddAysnc(ResponseFromStudentMapper);
            if (res == "Exist")
                return  UnprocessableEntity<string>("Name is Exist");
            else if (res == "Success")
                return Created("Added Sucessfully");
            else
                return BadRequest<string>();
        }
        #endregion
    }
}
