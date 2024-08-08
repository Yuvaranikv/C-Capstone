using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _repository;

        public GenresController(IGenreRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a paginated list of genres.
        /// </summary>
        /// <param name="page">The page number to retrieve (default is 1).</param>
        /// <param name="limit">The number of items per page (default is 10).</param>
        /// <returns>A paginated list of genres and the total count of genres.</returns>
        /// <response code="200">Returns the paginated list of genres and total count.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genres>>> GetGenres([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var genres = await _repository.GetGenresAsync(page, limit);
            var totalCount = await _repository.GetAllGenresAsync();
            return Ok(new { genres, totalCount });
        }

        /// <summary>
        /// Retrieves a list of all genres.
        /// </summary>
        /// <returns>A list of all genres.</returns>
        /// <response code="200">Returns the list of all genres.</response>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Genres>>> GetAllGenres()
        {
            var genres = await _repository.GetAllGenresAsync();
            return Ok(genres);
        }

        /// <summary>
        /// Retrieves a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre to retrieve.</param>
        /// <returns>The genre with the specified ID.</returns>
        /// <response code="200">Returns the genre with the specified ID.</response>
        /// <response code="404">If the genre with the specified ID is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Genres>> GetGenreByIdAsync(int id)
        {
            var genre = await _repository.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        /// <summary>
        /// Adds a new genre.
        /// </summary>
        /// <param name="genreDto">The genre details to create.</param>
        /// <returns>The created genre.</returns>
        /// <response code="201">Returns the created genre.</response>
        /// <response code="400">If the genre name is not provided.</response>

        [HttpPost("add")]
        public async Task<ActionResult<Genres>> AddGenre([FromBody] GenreCreateDto genreDto)
        {
            if (genreDto == null || string.IsNullOrEmpty(genreDto.genre_name))
            {
                return BadRequest("Genre name is required");
            }

            var genre = new Genres
            {
                genre_name = genreDto.genre_name,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };

            var createdGenre = await _repository.AddGenreAsync(genre);
            return StatusCode(StatusCodes.Status201Created, createdGenre);
        }

        /// <summary>
        /// Updates an existing genre.
        /// </summary>
        /// <param name="id">The ID of the genre to update.</param>
        /// <param name="genreDto">The updated genre details.</param>
        /// <returns>The updated genre.</returns>
        /// <response code="200">Returns the updated genre.</response>
        /// <response code="400">If the genre name is not provided.</response>
        /// <response code="404">If the genre with the specified ID is not found.</response>
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Genres>> UpdateGenre(int id, [FromBody] GenreCreateDto genreDto)
        {
            if (genreDto == null || string.IsNullOrEmpty(genreDto.genre_name))
            {
                return BadRequest("Genre name is required");
            }

            var updatedGenre = await _repository.UpdateGenreAsync(id, genreDto);
            if (updatedGenre == null) return NotFound();
            return Ok(updatedGenre);
        }

        /// <summary>
        /// Deletes a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre to delete.</param>
        /// <returns>No content on success.</returns>
        /// <response code="204">Indicates that the genre was successfully deleted.</response>
        /// <response code="404">If the genre with the specified ID is not found.</response>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _repository.DeleteGenreAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
