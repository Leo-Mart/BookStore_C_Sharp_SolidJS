using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Reviews;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/books/{bookId}/reviews")]
    public class ReviewsController(
        ILogger<ReviewsController> logger,
        IReviewRepository reviewRepository,
        IBookRepository bookRepository,
        UserManager<AppUser> userMananger
    ) : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger =
            logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IReviewRepository _reviewRepo = reviewRepository;

        private readonly IBookRepository _bookRepo = bookRepository;
        private readonly UserManager<AppUser> _userManager = userMananger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(int bookId)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                _logger.LogInformation($"Book with ID: {bookId} was not found.");
                return NotFound();
            }

            var reviewsForBook = await _reviewRepo.GetReviewsForBookAsync(bookId);

            if (reviewsForBook == null)
            {
                _logger.LogInformation($"Book with {bookId} was not found.");
                return NotFound();
            }

            var reviewsForBookDto = reviewsForBook.Select(b => b.ToReviewDto());

            return Ok(reviewsForBookDto);
        }

        [HttpGet("{reviewId}", Name = "GetReview")]
        public async Task<ActionResult<ReviewDto>> GetReview(int bookId, int reviewId)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                _logger.LogInformation($"Book with ID: {bookId} was not found.");
                return NotFound();
            }
            var reviewForBook = await _reviewRepo.GetReviewForBookAsync(bookId, reviewId);

            if (reviewForBook == null)
            {
                return NotFound();
            }

            return Ok(reviewForBook.ToReviewDto());
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> CreateReview(int bookId, CreateReviewDto review)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Unauthorized();
            }

            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var reviewToSave = review.ToReviewFromCreateDto();

            reviewToSave.AppUserId = userId;
            reviewToSave.Reviewer = user;
            var savedReview = await _reviewRepo.CreateReviewAsync(reviewToSave);

            return CreatedAtAction(
                "GetReview",
                new { bookId = savedReview.BookId, reviewId = savedReview.Id },
                savedReview.ToReviewDto()
            );
        }

        [HttpPut("{reviewId}")]
        public async Task<ActionResult> UpdateReview(
            int bookId,
            int reviewId,
            UpdateReviewDto review
        )
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var updatedReview = await _reviewRepo.UpdateReviewAsync(reviewId, review);

            return Ok(updatedReview);
        }

        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(int bookId, int reviewId)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var deletedReview = await _reviewRepo.DeleteReviewAsync(reviewId);

            if (deletedReview == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
