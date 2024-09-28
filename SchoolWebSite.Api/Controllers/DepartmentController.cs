using Microsoft.AspNetCore.Mvc;
using SchoolWebSite.Api.Controllers.Base;
using SchoolWebSite.Core.Features.Department.Queries.Requests;
using SchoolWebSite.Data.AppMetaData;

namespace SchoolWebSite.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        #region Controllers
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDepartmentByIdQuery(id));   // can be use two different way for this   1- create constructor in this class or {Id = id}
            return NewResult(response);
        }
        #endregion
    }
}
