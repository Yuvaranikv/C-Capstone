using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(int page, int limit);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<int> GetTotalBookCountAsync();
    }
}
