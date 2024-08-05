using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _repository;

        public GenresController(IGenreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genres>>> GetGenres([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var genres = await _repository.GetGenresAsync(page, limit);
            var totalCount = await _repository.GetAllGenresAsync();
            return Ok(new { genres, totalCount });
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Genres>>> GetAllGenres()
        {
            var genres = await _repository.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genres>> GetGenreByIdAsync(int id)
        {
            var genre = await _repository.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Genres>> AddGenre([FromBody] GenreCreateDto genreDto)
        {
            if (genreDto == null || string.IsNullOrEmpty(genreDto.GenreName))
            {
                return BadRequest("Genre name is required");
            }

            var genre = new Genres
            {
                GenreName = genreDto.GenreName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdGenre = await _repository.AddGenreAsync(genre);
            return StatusCode(StatusCodes.Status201Created, createdGenre);
        }


        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Genres>> UpdateGenre(int id, [FromBody] GenreCreateDto genreDto)
        {
            if (genreDto == null || string.IsNullOrEmpty(genreDto.GenreName))
            {
                return BadRequest("Genre name is required");
            }

            var updatedGenre = await _repository.UpdateGenreAsync(id, genreDto);
            if (updatedGenre == null) return NotFound();
            return Ok(updatedGenre);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _repository.DeleteGenreAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
