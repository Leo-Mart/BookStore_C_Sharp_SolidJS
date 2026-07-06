using System.ComponentModel.DataAnnotations;
using BookStore.Models.Users;

namespace BookStore.Models.Wishlists
{
    public class Wishlist : BaseEntity
    {
        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = null!;
        [Required]
        public string Name { get; set; } = "Default";
        public bool IsDefault { get; set; } = true;
        public string? Description { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();

    }
}