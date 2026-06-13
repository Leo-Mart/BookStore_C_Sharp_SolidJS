using BookStore.Models.Reviews;

namespace BookStore.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToReviewDto(this Review reviewModel)
        {
            return new ReviewDto
            {
                Id = reviewModel.Id,
                Title = reviewModel.Title,
                Text = reviewModel.Text,
                Score = reviewModel.Score,
                Reviewer = reviewModel.Reviewer.ToReviewUserInfoFromAppUser()
            };
        }

        public static Review ToReviewFromCreateDto(this CreateReviewDto reviewDto)
        {
            return new Review
            {
                Title = reviewDto.Title,
                Text = reviewDto.Text,
                Score = reviewDto.Score,
                BookId = reviewDto.BookId,
                AppUserId = reviewDto.AppUserId
            };
        }

    }
}