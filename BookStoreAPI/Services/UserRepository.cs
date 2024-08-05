using BookStoreAPI.DbContexts;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace BookStoreAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext _context;

        public UserRepository(BookStoreContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _context.Users.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<User> GetUserByCredentialsAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
    }
