#region
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolWebSite.Core.Features.Students.Queries.Models;
#endregion

namespace SchoolWebSite.Api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("/Students/List")]
        public async Task<IActionResult> GetStudentList()
        {
            var res = await _mediator.Send(new GetStudentListQuery());
            return Ok(res);
        }
    }
}
