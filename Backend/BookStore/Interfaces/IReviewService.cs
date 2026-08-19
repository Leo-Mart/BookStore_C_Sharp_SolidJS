using BookStore.Models.Reviews;

namespace BookStore.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>?> GetAllReviewsForBook(int bookId);
        Task<ReviewDto?> GetOneReviewForBook(int bookId, int reviewId);
        Task<ReviewDto?> CreateNewReviewForBook(
            int bookId,
            string userId,
            CreateReviewDto newReview
        );
        Task<ReviewDto?> UpdateReview(int bookId, int reviewId, UpdateReviewDto updateReview);
        Task<ReviewDto?> DeleteReview(int bookId, int reviewId);
    }
}
