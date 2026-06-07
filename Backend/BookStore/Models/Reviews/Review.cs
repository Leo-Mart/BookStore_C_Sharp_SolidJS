using System.ComponentModel.DataAnnotations;
using BookStore.Models;
using BookStore.Models.Users;

namespace BookStore.Models.Reviews
{
    public class Review : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Score { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}