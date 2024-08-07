using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<authors>> GetAuthorsAsync(int page, int limit);
        Task<IEnumerable<authors>> GetAllAuthorsAsync();
        Task<authors> GetAuthorByIdAsync(int id);
        Task<authors> AddAuthorAsync(authors author);
        Task<authors> UpdateAuthorAsync(int id, authors author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
