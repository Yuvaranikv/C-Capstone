using BookStoreAPI.DbContexts;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(int page, int limit)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.IsActive)
                .OrderByDescending(b => b.CreatedAt)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.IsActive)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
            existingBook.GenreId = book.GenreId;
            existingBook.Price = book.Price;
            existingBook.PublicationDate = book.PublicationDate;
            existingBook.ISBN = book.ISBN;
            existingBook.ImageURL = book.ImageURL;
            existingBook.Description = book.Description;
            existingBook.UpdatedAt = book.UpdatedAt;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            book.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalBookCountAsync()
        {
            return await _context.Books.CountAsync(b => b.IsActive);
        }
    }
}