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
        public async Task<IEnumerable<userstest>> GetActiveUsersAsync()
        {
            return await _context.Userstest.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<userstest> GetUserByCredentialsAsync(string username, string password)
        {
            return await _context.Userstest
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
    }
