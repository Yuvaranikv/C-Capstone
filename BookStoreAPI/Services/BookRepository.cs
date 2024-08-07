using BookStoreAPI.DbContexts;
using BookStoreAPI.DTOs;
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

        public async Task<IEnumerable<BookDto>> GetBooksAsync(int page, int limit)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.isActive)
                .OrderByDescending(b => b.createdAt)
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(b => new BookDto
                {
                    book_id = b.book_id,
                    title = b.title,
                    author_id = b.author_id,
                    Author = new AuthorCreateDto
                    {
                        author_id = b.Author.author_id,
                        Name = b.Author.Name,
                        Biography = b.Author.Biography
                    },
                    genre_id = b.genre_id,
                    Genre = new GenreCreateDto
                    {
                        genre_id = b.Genres.genre_id,
                        genre_name = b.Genres.genre_name
                    },
                    price = b.price,
                    publication_date = b.publication_date,
                    ISBN = b.ISBN,
                    imageURL = b.imageURL,
                    description = b.description,
                    isActive = b.isActive,
                    createdAt = b.createdAt,
                    updatedAt = b.updatedAt
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.isActive)
                .Select(b => new BookDto
                {
                    book_id = b.book_id,
                    title = b.title,
                    author_id = b.author_id,
                    Author = new AuthorCreateDto
                    {
                        author_id = b.Author.author_id,
                        Name = b.Author.Name,
                        Biography = b.Author.Biography
                    },
                    genre_id = b.genre_id,
                    Genre = new GenreCreateDto
                    {
                        genre_id = b.Genres.genre_id,
                        genre_name = b.Genres.genre_name
                    },
                    price = b.price,
                    publication_date = b.publication_date,
                    ISBN = b.ISBN,
                    imageURL = b.imageURL,
                    description = b.description,
                    isActive = b.isActive,
                    createdAt = b.createdAt,
                    updatedAt = b.updatedAt
                })
                .ToListAsync();
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.book_id == id)
                .Select(b => new BookDto
                {
                    book_id = b.book_id,
                    title = b.title,
                    author_id = b.author_id,
                    Author = new AuthorCreateDto
                    {
                        author_id = b.Author.author_id,
                        Name = b.Author.Name,
                        Biography = b.Author.Biography
                    },
                    genre_id = b.genre_id,
                    Genre = new GenreCreateDto
                    {
                        genre_id = b.Genres.genre_id,
                        genre_name = b.Genres.genre_name
                    },
                    price = b.price,
                    publication_date = b.publication_date,
                    ISBN = b.ISBN,
                    imageURL = b.imageURL,
                    description = b.description,
                    isActive = b.isActive,
                    createdAt = b.createdAt,
                    updatedAt = b.updatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<books> AddBookAsync(books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<books> UpdateBookAsync(int id, books book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.title = book.title;
            existingBook.author_id = book.author_id;
            existingBook.genre_id = book.genre_id;
            existingBook.price = book.price;
            existingBook.publication_date = book.publication_date;
            existingBook.ISBN = book.ISBN;
            existingBook.imageURL = book.imageURL;
            existingBook.description = book.description;
            existingBook.updatedAt = book.updatedAt;

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

            book.isActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalBookCountAsync()
        {
            return await _context.Books.CountAsync(b => b.isActive);
        }
    }
}