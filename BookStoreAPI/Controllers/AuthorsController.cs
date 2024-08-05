using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var authors = await _repository.GetAuthorsAsync(page, limit);
            var totalCount = await _repository.GetAllAuthorsAsync();
            return Ok(new { authors, totalCount });
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _repository.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorByIdAsync(int id)
        {
            var author = await _repository.GetAuthorByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] AuthorCreateDto authorDto)
        {
            if (authorDto == null || string.IsNullOrEmpty(authorDto.Name))
            {
                return BadRequest("Author name is required");
            }

            var author = new Author
            {
                Name = authorDto.Name,
                Biography = authorDto.Biography,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdAuthor = await _repository.AddAuthorAsync(author);
            return StatusCode(StatusCodes.Status201Created, createdAuthor);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, [FromBody] AuthorCreateDto authorDto)
        {
            if (authorDto == null || string.IsNullOrEmpty(authorDto.Name))
            {
                return BadRequest("Author name is required");
            }

            var author = new Author
            {
                Name = authorDto.Name,
                Biography = authorDto.Biography
            };

            var updatedAuthor = await _repository.UpdateAuthorAsync(id, author);
            if (updatedAuthor == null) return NotFound();
            return Ok(updatedAuthor);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _repository.DeleteAuthorAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
   
