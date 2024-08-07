using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<userstest>> GetActiveUsersAsync();
        Task<userstest> GetUserByCredentialsAsync(string username, string password);

    }
}
