using BookStore.Models.Reviews;

namespace BookStore.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsForBookAsync(int bookId);
        Task<ICollection<ReviewInfoDto>?> GetReviewsForUserByIdAsync(string userId);
        Task<Review?> GetReviewForBookAsync(int bookId, int reviewId);
        Task<Review> CreateReviewAsync(Review review);
        Task<Review?> UpdateReviewAsync(int reviewId, UpdateReviewDto updateDto);
        Task<Review?> DeleteReviewAsync(int reviewId);
    }
}