using MediatR;

namespace Valemas.Application.Users.Get
{
    public record GetUsersQuery : IRequest<IEnumerable<GetUsersDto>>;
}
