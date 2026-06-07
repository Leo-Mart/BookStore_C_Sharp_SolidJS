using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Reviews
{
    public class UpdateReviewDto
    {
        [Required(ErrorMessage = "A title is required.")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Text { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}