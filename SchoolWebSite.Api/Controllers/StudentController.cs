#region
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolWebSite.Core.Features.Students.Queries.Models;
using SchoolWebSite.Core.Features.Students.Queries.Requests;
using SchoolWebSite.Data.AppMetaData;
#endregion

namespace SchoolWebSite.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Fields 
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var res = await _mediator.Send(new GetStudentListQuery());
            return Ok(res);
        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var res = await _mediator.Send(new GetStudentByIdQuery(id));   // can be use two different way for this 1- create constructor in this class or {Id = id}
            return Ok(res);
        }
    }
}
