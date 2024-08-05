using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<User> GetUserByCredentialsAsync(string username, string password);

    }
}
