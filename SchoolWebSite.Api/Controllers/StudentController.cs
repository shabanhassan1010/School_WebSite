#region
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolWebSite.Api.Controllers.Base;
using SchoolWebSite.Core.Features.Students.Commands.Models;
using SchoolWebSite.Core.Features.Students.Queries.Models;
using SchoolWebSite.Core.Features.Students.Queries.Requests;
using SchoolWebSite.Data.AppMetaData;
#endregion

namespace SchoolWebSite.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var res = await Mediator.Send(new GetStudentListQuery());
            return NewResult(res);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var res = await Mediator.Send(new GetStudentByIdQuery(id));   // can be use two different way for this 1- create constructor in this class or {Id = id}
            return NewResult(res);
        }

        [HttpPost(Router.StudentRouting.AddStudent)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var res = await Mediator.Send(command);  
            return NewResult(res);
        }
    }
}
