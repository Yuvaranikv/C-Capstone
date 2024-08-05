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

        public async Task<IEnumerable<Author>> GetAuthorsAsync(int page, int limit)
        {
            var offset = (page - 1) * limit;
            return await _context.Authors
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedAt)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Where(a => a.IsActive)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                .Where(a => a.AuthorId == id && a.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthorAsync(int id, Author author)
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
    
