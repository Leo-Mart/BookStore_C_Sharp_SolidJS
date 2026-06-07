using BookStore.Models.Users;

namespace BookStore.Models.Reviews
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Score { get; set; }
        public int UserId { get; set; }


    }
}