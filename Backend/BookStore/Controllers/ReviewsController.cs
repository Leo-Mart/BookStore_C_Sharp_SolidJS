using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Models.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/books/{bookId}/reviews")]
    public class ReviewsController(ILogger<ReviewsController> logger, IReviewService reviewService)
        : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger =
            logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IReviewService _reviewService = reviewService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(int bookId)
        {
            var reviewsForBookDto = await _reviewService.GetAllReviewsForBook(bookId);
            if (reviewsForBookDto == null)
            {
                return NotFound();
            }

            return Ok(reviewsForBookDto);
        }

        [HttpGet("{reviewId}", Name = "GetReview")]
        public async Task<ActionResult<ReviewDto>> GetReview(int bookId, int reviewId)
        {
            var reviewForBook = await _reviewService.GetOneReviewForBook(bookId, reviewId);
            if (reviewForBook == null)
            {
                return NotFound();
            }

            return Ok(reviewForBook);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> CreateReview(int bookId, CreateReviewDto review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var savedReview = await _reviewService.CreateNewReviewForBook(bookId, userId, review);
            if (savedReview == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(
                "GetReview",
                new { bookId = savedReview.BookId, reviewId = savedReview.Id },
                savedReview
            );
        }

        [HttpPut("{reviewId}")]
        public async Task<ActionResult> UpdateReview(
            int bookId,
            int reviewId,
            UpdateReviewDto review
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedReview = await _reviewService.UpdateReview(bookId, reviewId, review);

            return Ok(updatedReview);
        }

        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(int bookId, int reviewId)
        {
            var deletedReview = await _reviewService.DeleteReview(bookId, reviewId);
            if (deletedReview == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
