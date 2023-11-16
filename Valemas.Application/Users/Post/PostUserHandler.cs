using MediatR;
using Valemas.Domain.Users;

namespace Valemas.Application.Users.Post
{
    public class PostUserHandler : IRequestHandler<PostUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public PostUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Username, request.Email, request.Password);

            await _userRepository.AddAsync(user, cancellationToken);
        }
    }
}
