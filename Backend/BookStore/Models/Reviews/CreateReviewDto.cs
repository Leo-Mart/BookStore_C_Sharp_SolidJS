using System.ComponentModel.DataAnnotations;
using BookStore.Models.Users;

namespace BookStore.Models.Reviews
{
    public class CreateReviewDto
    {
        [Required(ErrorMessage = "A title is required.")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Text { get; set; } = string.Empty;
        public int Score { get; set; }
        public int BookId { get; set; }
        public int UserId {get; set;}
        public ReviewUserInfoDto Reviewer {get;set;} = null!;

    }
}