using MediatR;

namespace Valemas.Application.Users.Post
{
    public record PostUserCommand(string Username, string Email, string Password) : IRequest;
}
