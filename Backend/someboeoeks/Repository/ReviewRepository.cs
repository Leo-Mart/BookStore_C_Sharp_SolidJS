using Microsoft.EntityFrameworkCore;
using someboeoeks.DbContexts;
using someboeoeks.Interfaces;
using someboeoeks.Models.Reviews;

namespace someboeoeks.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Review> CreateReviewAsync(Review review)
        {
            review.CreatedAt = DateTime.UtcNow;
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> DeleteReviewAsync(int reviewId)
        {
            var foundReview = await _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefaultAsync();

            if (foundReview == null)
            {
                return null;
            }

            _context.Reviews.Remove(foundReview);
            await _context.SaveChangesAsync();
            return foundReview;
        }

        public async Task<Review?> GetReviewForBookAsync(int bookId, int reviewId)
        {
            return await _context.Reviews.Where(r => r.BookId == bookId && r.Id == reviewId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsForBookAsync(int bookId)
        {
            return await _context.Reviews.Where(r => r.BookId == bookId).ToListAsync();
        }

        public async Task<Review?> UpdateReviewAsync(int reviewId, UpdateReviewDto updateDto)
        {            
            var reviewFromDb =  await _context.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);

            if (reviewFromDb == null)
            {
                return null;
            } 

            reviewFromDb.Title = updateDto.Title;
            reviewFromDb.Text = updateDto.Text;
            reviewFromDb.Score = updateDto.Score;
            reviewFromDb.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return reviewFromDb;
        }
    }
}