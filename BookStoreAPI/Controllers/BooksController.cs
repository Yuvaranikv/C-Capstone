using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]")]
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

        /// <summary>
        /// Retrieves a paginated list of books.
        /// </summary>
        /// <param name="page">The page number to retrieve (default is 1).</param>
        /// <param name="limit">The number of books per page (default is 10).</param>
        /// <returns>A list of books with total count.</returns>
        /// <response code="200">Returns the paginated list of books and total count.</response>
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var books = await _repository.GetBooksAsync(page, limit);
            var totalCount = await _repository.GetTotalBookCountAsync();

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(new { books = bookDtos, totalCount = books.Count() });
        }

        /// <summary>
        /// Retrieves a list of all books.
        /// </summary>
        /// <returns>A list of all books with total count.</returns>
        /// <response code="200">Returns the list of all books and total count.</response>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _repository.GetAllBooksAsync();
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(new { books = bookDtos, totalCount = books.Count() });
        }

        /// <summary>
        /// Retrieves a specific book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The requested book if found.</returns>
        /// <response code="200">Returns the requested book.</response>
        /// <response code="404">If the book with the specified ID is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _repository.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        /// <summary>
        /// Adds a new book.
        /// </summary>
        /// <param name="bookDto">The book details to add.</param>
        /// <returns>The newly created book.</returns>
        /// <response code="201">Returns the newly created book.</response>
        /// <response code="400">If the book details are invalid.</response>
        [HttpPost("add")]
        public async Task<ActionResult<BookDto>> AddBook([FromBody] BookCreateDto bookDto)
        {
            if (bookDto == null || string.IsNullOrEmpty(bookDto.title))
            {
                return BadRequest("Book title is required");
            }

            var book = _mapper.Map<books>(bookDto);
            book.createdAt = DateTime.UtcNow;
            book.updatedAt = DateTime.UtcNow;

            var createdBook = await _repository.AddBookAsync(book);

            var createdBookDto = _mapper.Map<BookDto>(createdBook);
            return StatusCode(StatusCodes.Status201Created, createdBookDto);
        }

        /// <summary>
        /// Updates an existing book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="bookDto">The updated book details.</param>
        /// <returns>The updated book.</returns>
        /// <response code="200">Returns the updated book.</response>
        /// <response code="404">If the book with the specified ID is not found.</response>
        /// <response code="400">If the book details are invalid.</response>
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, [FromBody] BookCreateDto bookDto)
        {
            if (bookDto == null || string.IsNullOrEmpty(bookDto.title))
            {
                return BadRequest("Book title is required");
            }

            var book = _mapper.Map<books>(bookDto);
            book.createdAt = DateTime.UtcNow;
            book.updatedAt = DateTime.UtcNow;

            var updatedBook = await _repository.UpdateBookAsync(id, book);
            if (updatedBook == null) return NotFound();

            var updatedBookDto = _mapper.Map<BookDto>(updatedBook);
            return Ok(updatedBookDto);
        }

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>No content if the book is successfully deleted.</returns>
        /// <response code="204">If the book is successfully deleted.</response>
        /// <response code="404">If the book with the specified ID is not found.</response>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _repository.DeleteBookAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <returns>The path to the uploaded file.</returns>
        /// <response code="200">Returns the file path of the uploaded file.</response>
        /// <response code="400">If no file is uploaded.</response>
        /// <response code="500">If an error occurs while uploading the file.</response>
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