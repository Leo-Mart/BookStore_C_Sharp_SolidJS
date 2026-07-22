using System.Text.Json;
using BookStore.Interfaces;
using BookStore.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/find")]
    public class FindController(ILogger<FindController> logger, IFindServce findService)
        : ControllerBase
    {
        private readonly ILogger<FindController> _logger =
            logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IFindServce _findService = findService;
        const int maxBooksPageSize = 100;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithoutReviewsDto>>> SearchBooks(
            [FromQuery] string? searchQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 12
        )
        {
            if (pageSize > maxBooksPageSize)
            {
                pageSize = maxBooksPageSize;
            }

            var (books, paginationMetaData) = await _findService.SearchForBooks(
                searchQuery,
                pageNumber,
                pageSize
            );

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            return Ok(books);
        }
    }
}
