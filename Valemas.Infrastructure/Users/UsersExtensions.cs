using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Valemas.Domain.Users;

namespace Valemas.Infrastructure.Users
{
    public static class UsersExtensions
    {
        public static IServiceCollection AddUserPersistence(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserRepository, UserHttpRepository>();
        }

        public static IServiceCollection ConfigureUserEndpoint(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<UserConfiguration>(configuration.GetRequiredSection(nameof(UserConfiguration)));
        }
    }
}
