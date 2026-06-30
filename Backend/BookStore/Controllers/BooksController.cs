using System.Text.Json;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(ILogger<BooksController> logger, IBookRepository bookRepository) : ControllerBase
    {
        private readonly ILogger<BooksController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IBookRepository _booksRepo = bookRepository;
        const int maxBooksPageSize = 20;

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