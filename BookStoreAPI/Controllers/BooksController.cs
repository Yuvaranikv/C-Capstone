using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var books = await _repository.GetBooksAsync(page, limit);
            var totalCount = await _repository.GetTotalBookCountAsync();

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(new { books = bookDtos, totalCount });
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _repository.GetAllBooksAsync();
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(new { books = bookDtos, totalCount = books.Count() });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _repository.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost("add")]
        public async Task<ActionResult<BookDto>> AddBook([FromBody] BookCreateDto bookDto)
        {
            if (bookDto == null || string.IsNullOrEmpty(bookDto.Title))
            {
                return BadRequest("Book title is required");
            }

            var book = _mapper.Map<Book>(bookDto);
            book.CreatedAt = DateTime.UtcNow;
            book.UpdatedAt = DateTime.UtcNow;

            var createdBook = await _repository.AddBookAsync(book);

            var createdBookDto = _mapper.Map<BookDto>(createdBook);
            return StatusCode(StatusCodes.Status201Created, createdBookDto);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, [FromBody] BookCreateDto bookDto)
        {
            if (bookDto == null || string.IsNullOrEmpty(bookDto.Title))
            {
                return BadRequest("Book title is required");
            }

            var book = _mapper.Map<Book>(bookDto);
            book.CreatedAt = DateTime.UtcNow;
            book.UpdatedAt = DateTime.UtcNow;

            var updatedBook = await _repository.UpdateBookAsync(id, book);
            if (updatedBook == null) return NotFound();

            var updatedBookDto = _mapper.Map<BookDto>(updatedBook);
            return Ok(updatedBookDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _repository.DeleteBookAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var filePath = Path.Combine("uploads", $"{DateTime.Now:yyyyMMddHHmmssfff}{Path.GetExtension(file.FileName)}");

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}