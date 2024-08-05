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
                .Where(g => g.IsActive)
                .OrderByDescending(g => g.CreatedAt)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Genres>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Where(g => g.IsActive)
                .ToListAsync();
        }
        public async Task<Genres> GetGenreByIdAsync(int id)
        {
            return await _context.Genres
                .Where(g => g.GenreId == id && g.IsActive)
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

            existingGenre.GenreName = genreDto.GenreName;
            existingGenre.UpdatedAt = DateTime.UtcNow; // Update the timestamp

            await _context.SaveChangesAsync();
            return existingGenre;
        }


        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return false;

            genre.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
    }