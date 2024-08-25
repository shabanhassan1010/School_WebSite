#region
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
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }


        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));   // can be use two different way for this 1- create constructor in this class or {Id = id}
            return NewResult(response);
        }


        [HttpPost(Router.StudentRouting.AddStudent)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command) // I Use [FromBody] with Edit , Add
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.StudentRouting.EditStudent)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command) // I Use [FromBody] with Edit , Add
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}

