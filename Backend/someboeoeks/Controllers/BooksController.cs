using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using someboeoeks.Interfaces;
using someboeoeks.Mappers;
using someboeoeks.Models.Books;

namespace someboeoeks.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/books")]
    public class BooksController : ControllerBase 
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _booksRepo;
        const int maxBooksPageSize = 20;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _booksRepo = bookRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithoutReviewsDto>>> GetBooks(string? title, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxBooksPageSize)
            {
                pageSize = maxBooksPageSize;
            }

            var (books, paginationMetaData) = await _booksRepo.GetBooksAsync(title, searchQuery, pageNumber, pageSize);
            var bookDtos = books.Select(b => b.ToBookWithoutReviewsDto());
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var foundBook = await _booksRepo.GetBookByIdAsync(id);

            if (foundBook == null)
            {
                return NotFound();
            }

            return Ok(foundBook.ToBookDto());
        }
    }
}