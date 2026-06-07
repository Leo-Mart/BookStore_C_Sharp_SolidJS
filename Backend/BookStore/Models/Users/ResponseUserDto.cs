using System.ComponentModel.DataAnnotations;
using BookStore.Models.Reviews;

namespace BookStore.Models.Users
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}