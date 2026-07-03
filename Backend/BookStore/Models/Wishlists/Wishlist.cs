using System.ComponentModel.DataAnnotations;
using BookStore.Models.Users;

namespace BookStore.Models.Wishlists
{
    public class Wishlist : BaseEntity
    {
        [Required]
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
        [Required]
        public string Name { get; set; } = "Default";
        public bool IsDefault { get; set; } = true;
        public string? Description { get; set; }
        public ICollection<WishlistItem> WishlistItems = new List<WishlistItem>();

    }
}