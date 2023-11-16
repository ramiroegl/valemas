namespace Valemas.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken cancellation = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellation = default);
    }
}
