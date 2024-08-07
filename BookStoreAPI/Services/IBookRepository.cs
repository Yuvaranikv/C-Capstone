using BookStoreAPI.Models;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooksAsync(int page, int limit);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<books> AddBookAsync(books book);
        Task<books> UpdateBookAsync(int id, books book);
        Task<bool> DeleteBookAsync(int id);
        Task<int> GetTotalBookCountAsync();
    }
}
