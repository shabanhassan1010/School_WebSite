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
                                                        , IRequestHandler<EditStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
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
            if (res.Equals("Success"))
                return Created("Added Sucessfully");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check If Student Exist or not Before Edit 
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            // if Student is not Exist return not found 
            if (student == null)
                return NotFound<string>("Name is not Found");
            // else Mapping between Requst and Student
            var studentMapper = _mapper.Map<Student>(request);
            // call servise to Edit 
            var studentService = await _studentService.EditAysnc(studentMapper);
            if (studentService == "Success")
                return Success($"Edit Successfully {studentMapper.StudID}");
            else
                return BadRequest<string>();
        }
        #endregion
    }
}
