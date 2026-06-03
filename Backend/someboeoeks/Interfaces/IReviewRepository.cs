using someboeoeks.Models.Reviews;

namespace someboeoeks.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsForBookAsync(int bookId);
        Task<Review?> GetReviewForBookAsync(int bookId, int reviewId);
        Task<Review> CreateReviewAsync(Review review);
        Task<Review?> UpdateReviewAsync(int reviewId, UpdateReviewDto updateDto);
        Task<Review?> DeleteReviewAsync(int reviewId);
    }
}