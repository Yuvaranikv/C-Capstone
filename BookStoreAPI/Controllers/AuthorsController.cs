using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    /// <summary>
    /// Controller for managing authors in the bookstore.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a paginated list of authors.
        /// </summary>
        /// <param name="page">The page number for pagination (default is 1).</param>
        /// <param name="limit">The number of authors to return per page (default is 10).</param>
        /// <returns>An action result containing a list of authors and the total count.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<authors>>> GetAuthors([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var authors = await _repository.GetAuthorsAsync(page, limit);
            var totalCount = await _repository.GetAllAuthorsAsync();
            return Ok(new { authors, totalCount });
        }
        /// <summary>
        /// Retrieves a list of all authors.
        /// </summary>
        /// <returns>An action result containing a list of all authors.</returns>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<authors>>> GetAllAuthors()
        {
            var authors = await _repository.GetAllAuthorsAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Retrieves a specific author by their id.
        /// </summary>
        /// <param name="id">The unique identifier of the author.</param>
        /// <returns>An action result containing the author if found; otherwise, a 404 Not Found status.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<authors>> GetAuthorByIdAsync(int id)
        {
            var author = await _repository.GetAuthorByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        /// <summary>
        /// Adds a new author to the bookstore.
        /// </summary>
        /// <param name="authorDto">The data transfer object containing author details.</param>
        /// <returns>An action result containing the created author if successful; otherwise, a 400 Bad Request status.</returns>
        [HttpPost("add")]
        public async Task<ActionResult<authors>> AddAuthor([FromBody] AuthorCreateDto authorDto)
        {
            if (authorDto == null || string.IsNullOrEmpty(authorDto.Name))
            {
                return BadRequest("Author name is required");
            }

            var author = new authors
            {
                Name = authorDto.Name,
                Biography = authorDto.Biography,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdAuthor = await _repository.AddAuthorAsync(author);
            return StatusCode(StatusCodes.Status201Created, createdAuthor);
        }

        /// <summary>
        /// Updates an existing author's details.
        /// </summary>
        /// <param name="id">The unique identifier of the author to update.</param>
        /// <param name="authorDto">The data transfer object containing updated author details.</param>
        /// <returns>An action result containing the updated author if successful; otherwise, a 404 Not Found status.</returns>
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<authors>> UpdateAuthor(int id, [FromBody] AuthorCreateDto authorDto)
        {
            if (authorDto == null || string.IsNullOrEmpty(authorDto.Name))
            {
                return BadRequest("Author name is required");
            }

            var author = new authors
            {
                Name = authorDto.Name,
                Biography = authorDto.Biography
            };

            var updatedAuthor = await _repository.UpdateAuthorAsync(id, author);
            if (updatedAuthor == null) return NotFound();
            return Ok(updatedAuthor);
        }

        /// <summary>
        /// Deletes an author by their identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the author to delete.</param>
        /// <returns>An action result indicating the outcome of the delete operation.</returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _repository.DeleteAuthorAsync(id);
            if (!result) return NotFound();
            HttpContext.Response.Headers.Add("X-Message", "Author Deleted successfully");
            return NoContent();
        }
    }
}
   
