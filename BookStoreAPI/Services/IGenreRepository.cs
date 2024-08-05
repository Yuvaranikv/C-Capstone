using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genres>> GetGenresAsync(int page, int limit);
        Task<IEnumerable<Genres>> GetAllGenresAsync();
        Task<Genres> GetGenreByIdAsync(int id);
        Task<Genres> AddGenreAsync(Genres genre);
        Task<Genres> UpdateGenreAsync(int id, GenreCreateDto genre);
        Task<bool> DeleteGenreAsync(int id);
    }
}
