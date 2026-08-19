using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Reviews;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class ReviewService(
        ILogger<ReviewService> logger,
        IReviewRepository reviewRepo,
        IBookRepository bookRepo,
        UserManager<AppUser> userManager
    ) : IReviewService
    {
        private readonly ILogger<ReviewService> _logger = logger;
        private readonly IReviewRepository _reviewRepo = reviewRepo;
        private readonly IBookRepository _bookRepo = bookRepo;
        private readonly UserManager<AppUser> _userManager = userManager;

        public async Task<ReviewDto?> CreateNewReviewForBook(
            int bookId,
            string userId,
            CreateReviewDto newReview
        )
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return null;
            }

            var reviewToSave = newReview.ToReviewFromCreateDto();

            reviewToSave.AppUserId = userId;
            reviewToSave.Reviewer = user;
            var savedReview = await _reviewRepo.CreateReviewAsync(reviewToSave);
            return savedReview.ToReviewDto();
        }

        public async Task<ReviewDto?> DeleteReview(int bookId, int reviewId)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return null;
            }

            var deletedReview = await _reviewRepo.DeleteReviewAsync(reviewId);

            if (deletedReview == null)
            {
                return null;
            }

            return deletedReview.ToReviewDto();
        }

        public async Task<IEnumerable<ReviewDto>?> GetAllReviewsForBook(int bookId)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                _logger.LogInformation($"Book with ID: {bookId} was not found.");
                return null;
            }

            var reviewsForBook = await _reviewRepo.GetReviewsForBookAsync(bookId);

            if (reviewsForBook == null)
            {
                _logger.LogInformation($"Book with {bookId} was not found.");
                return null;
            }

            var reviewsForBookDto = reviewsForBook.Select(b => b.ToReviewDto());
            return reviewsForBookDto;
        }

        public async Task<ReviewDto?> GetOneReviewForBook(int bookId, int reviewId)
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                _logger.LogInformation($"Book with ID: {bookId} was not found.");
                return null;
            }
            var reviewForBook = await _reviewRepo.GetReviewForBookAsync(bookId, reviewId);

            if (reviewForBook == null)
            {
                return null;
            }

            return reviewForBook.ToReviewDto();
        }

        public async Task<ReviewDto?> UpdateReview(
            int bookId,
            int reviewId,
            UpdateReviewDto updateReview
        )
        {
            if (!await _bookRepo.BookExistsAsync(bookId))
            {
                return null;
            }

            var updatedReview = await _reviewRepo.UpdateReviewAsync(reviewId, updateReview);
            if (updatedReview == null)
            {
                return null;
            }

            return updatedReview.ToReviewDto();
        }
    }
}
