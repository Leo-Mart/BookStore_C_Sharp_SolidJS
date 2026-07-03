using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Wishlists
{
    public class CreateWishlistItemDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int WishListId { get; set; }
    }
}