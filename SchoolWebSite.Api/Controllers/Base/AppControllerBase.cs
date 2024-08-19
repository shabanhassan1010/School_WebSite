#region
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolWebSite.Core.Bases;
using System.Net;
#endregion

namespace SchoolWebSite.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        #region Fields 
        private IMediator _mediatorInstanse;
        #endregion
        protected IMediator Mediator => _mediatorInstanse ??= HttpContext.RequestServices.GetService<IMediator>()!;

        #region Handle Functions 
        public ObjectResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new NotFoundObjectResult(response);
            }
        }
        #endregion
    }
}
