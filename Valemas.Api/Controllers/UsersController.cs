using MediatR;
using Microsoft.AspNetCore.Mvc;
using Valemas.Application.Users.Get;
using Valemas.Application.Users.Post;

namespace Valemas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<GetUsersDto>> Get()
        {
            var query = new GetUsersQuery();
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "PostUsers")]
        public async Task Post(PostUserCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
