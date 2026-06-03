using someboeoeks.Models.Reviews;

namespace someboeoeks.Mappers
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
                UserId = reviewModel.UserId
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
                UserId = reviewDto.UserId
            };
        }

        public static Review ToReviewFromUpdateDto(this UpdateReviewDto updateDto)
        {
            return new Review
            {
                Title = updateDto.Title,
                Text = updateDto.Text,
                Score = updateDto.Score
            };
        }

        public static UpdateReviewDto ToUpdateFromReviewDto(this Review reviewModel)
        {
            return new UpdateReviewDto
            {
                Title = reviewModel.Title,
                Text = reviewModel.Text,
                Score = reviewModel.Score,
            };
        }
    }
}