using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Wishlists
{
    public class CreateWishlistDto
    {
        [Required]
        public Guid AppUserId { get; set; }
        [Required]
        public string Name { get; set; } = "Default";
        public bool IsDefault { get; set; } = true;
        public string? Description { get; set; }
        [Required]
        public ICollection<WishlistItem> WishlistItems = new List<WishlistItem>();
    }
}