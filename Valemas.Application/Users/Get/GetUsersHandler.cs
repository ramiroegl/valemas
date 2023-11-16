using MediatR;
using Valemas.Domain.Users;

namespace Valemas.Application.Users.Get
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync(cancellationToken);

            var usersDto = users
                .Select(user => new GetUsersDto(user.Id, user.Username, user.Email));

            return usersDto;
        }
    }
}
