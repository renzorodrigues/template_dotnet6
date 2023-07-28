using System.Net;
using Braboz.Core.Handlers.Interfaces;
using Braboz.Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Braboz.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // QUERIES
        protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>() where TRequest : class, IQuery<TResult>, new()
        {
            return await ExecuteAsync<TRequest, TResult>(new TRequest());
        }

        // COMMANDS
        protected async Task<IActionResult> ExecuteCommandAsync<TRequest, TResult>(TRequest request) where TRequest : class, ICommand<TResult>
        {
            return await ExecuteAsync<TRequest, TResult>(request);
        }

        private async Task<IActionResult> ExecuteAsync<TRequest, TResult>(TRequest request) where TRequest : class, IRequest<Result<TResult>>
        {
            IActionResult actionResult;

            var result = await mediator.Send(request);

            if (result.IsSuccess)
            {
                actionResult = result.StatusCode switch
                {
                    HttpStatusCode.NoContent => NoContent(),
                    _ => Ok(result)
                };
            }
            else
            {
                actionResult = result.StatusCode switch
                {
                    HttpStatusCode.NotFound => NotFound(result),
                    HttpStatusCode.Unauthorized => Unauthorized(result),
                    _ => BadRequest(result)
                };
            }

            return actionResult;
        }
    }
}
