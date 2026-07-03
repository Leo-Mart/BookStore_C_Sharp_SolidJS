using System.ComponentModel.DataAnnotations;
using BookStore.Models.Addresses;
using BookStore.Models.Orders;
using BookStore.Models.PaymentMethods;
using BookStore.Models.Reviews;
using BookStore.Models.Wishlists;
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
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
        public ICollection<Wishlist> Wishlists {get;set;} = new List<Wishlist>();
    }
}