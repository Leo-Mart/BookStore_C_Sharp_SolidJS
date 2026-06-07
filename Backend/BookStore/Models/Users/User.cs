
using System.ComponentModel.DataAnnotations;
using BookStore.Models;
using BookStore.Models.Reviews;

namespace BookStore.Models.Users
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty; 

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}