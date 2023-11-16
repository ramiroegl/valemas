using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Valemas.Domain.Users;

namespace Valemas.Infrastructure.Users
{
    public class UserHttpRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<UserConfiguration> _options;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public UserHttpRepository(HttpClient httpClient, IOptions<UserConfiguration> options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task AddAsync(User user, CancellationToken cancellation = default)
        {
            var json = JsonSerializer.Serialize(user, _jsonSerializerOptions);
            StringContent content = new(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_options.Value.ServiceUrl, content, cancellation);
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellation = default)
        {
            var response = await _httpClient.GetAsync(_options.Value.ServiceUrl, cancellation);

            var responseString = await response.Content.ReadAsStringAsync(cancellation);

            IEnumerable<User> result = JsonSerializer.Deserialize<IEnumerable<User>>(responseString, _jsonSerializerOptions)!;

            return result;
        }
    }
}
