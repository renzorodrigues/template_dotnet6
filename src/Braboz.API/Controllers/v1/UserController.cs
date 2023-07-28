using Braboz.API.Controllers.Base;
using Braboz.Application.Models.User;
using Braboz.Application.Products.CQS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Braboz.API.Controllers.v1
{
    public class UserController : ApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() =>
            await ExecuteQueryAsync<GetAllUsersQuery, IEnumerable<GetAllUsersResponse>>();
    }
}
