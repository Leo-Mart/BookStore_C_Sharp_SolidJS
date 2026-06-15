using System.ComponentModel.DataAnnotations;
using BookStore.Models.Orders;
using BookStore.Models.Reviews;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models.Users
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}