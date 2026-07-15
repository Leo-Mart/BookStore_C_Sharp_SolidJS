using System.ComponentModel.DataAnnotations;
using BookStore.Models.Books;

namespace BookStore.Models.Wishlists
{
    public class WishlistItem : BaseEntity
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int WishListId { get; set; }
        public Book Book { get; set; } = null!;
        public Wishlist Wishlist { get; set; } = null!;
    }
}