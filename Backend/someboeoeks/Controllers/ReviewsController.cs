using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using someboeoeks.Interfaces;
using someboeoeks.Mappers;
using someboeoeks.Models.Reviews;

namespace someboeoeks.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/books/{bookId}/reviews")]
    public class ReviewsController : ControllerBase
    {

        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewRepository _reviewRepo;

        private readonly IBookRepository _bookRepo;

        public ReviewsController(ILogger<ReviewsController> logger, IReviewRepository reviewRepository, IBookRepository bookRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));            
            _reviewRepo = reviewRepository;
            _bookRepo = bookRepository;
        }
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

            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var reviewToSave = review.ToReviewFromCreateDto();
            var savedReview = await _reviewRepo.CreateReviewAsync(reviewToSave);

            return CreatedAtAction("GetReview",
            new
            {
                bookId = reviewToSave.BookId,
                reviewId = reviewToSave.Id
            },
            savedReview.ToReviewDto());
        }

        [HttpPut("{reviewId}")]
        public async Task<ActionResult> UpdateReview(int bookId, int reviewId, UpdateReviewDto review)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var updatedReview = await _reviewRepo.UpdateReviewAsync(reviewId, review);

            return Ok(updatedReview);

        }

        // [HttpPatch("{reviewId}")]
        // public async Task<ActionResult> PartialUpdateReview(int bookId, int reviewId, JsonPatchDocument<UpdateReviewDto> reviewPatch)
        // {
        //     //TODO: Move to repo? Delete?
        //     if (!await _bookRepo.BookExistsAsync(bookId))
        //     {
        //         return NotFound();
        //     }

        //     var reviewFromDb = await _reviewRepo.GetReviewForBookAsync(bookId, reviewId);

        //     if (reviewFromDb == null)
        //     {
        //         return NotFound();
        //     }

        //     var reviewToPatch = reviewFromDb.ToUpdateFromReviewDto();            

        //     reviewPatch.ApplyTo(reviewToPatch, ModelState);

        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (!TryValidateModel(reviewPatch))
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     reviewFromDb.Title = reviewToPatch.Title;
        //     reviewFromDb.Text = reviewToPatch.Text;
        //     reviewFromDb.Score = reviewToPatch.Score;
        //     reviewFromDb.Reviewer = reviewToPatch.Reviewer;

        //     return NoContent();
        // }

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