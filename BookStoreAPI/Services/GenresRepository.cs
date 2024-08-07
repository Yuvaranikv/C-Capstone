using BookStoreAPI.DbContexts;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services
{
    public class GenresRepository : IGenreRepository
    {
        private readonly BookStoreContext _context;

        public GenresRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genres>> GetGenresAsync(int page, int limit)
        {
            var offset = (page - 1) * limit;
            return await _context.Genres
                .Where(g => g.isActive)
                .OrderByDescending(g => g.createdAt)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Genres>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Where(g => g.isActive)
                .ToListAsync();
        }

        public async Task<Genres> GetGenreByIdAsync(int id)
        {
            return await _context.Genres
                .Where(g => g.genre_id == id && g.isActive)
                .FirstOrDefaultAsync();
        }

        public async Task<Genres> AddGenreAsync(Genres genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genres> UpdateGenreAsync(int id, GenreCreateDto genreDto)
        {
            var existingGenre = await _context.Genres.FindAsync(id);
            if (existingGenre == null) return null;

            existingGenre.genre_name = genreDto.genre_name;
            existingGenre.updatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingGenre;
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return false;

            genre.isActive = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}