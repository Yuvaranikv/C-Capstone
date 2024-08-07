using BookStoreAPI.DbContexts;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreContext _context;

        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<authors>> GetAuthorsAsync(int page, int limit)
        {
            var offset = (page - 1) * limit;
            return await _context.Authors
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedAt)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<authors>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Where(a => a.IsActive)
                .ToListAsync();
        }

        public async Task<authors> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                .Where(a => a.author_id == id && a.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<authors> AddAuthorAsync(authors author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<authors> UpdateAuthorAsync(int id, authors author)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);
            if (existingAuthor == null) return null;

            existingAuthor.Name = author.Name;
            existingAuthor.Biography = author.Biography;
            existingAuthor.UpdatedAt = DateTime.UtcNow; // Update the timestamp

            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            author.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
    
