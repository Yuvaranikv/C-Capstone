using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync(int page, int limit);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
