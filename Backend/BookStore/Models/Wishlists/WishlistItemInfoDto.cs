using BookStore.Models.Books;

namespace BookStore.Models.Wishlists
{
    public record WishlistItemInfoDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookItemInfoDto Book { get; set; } = null!;
        public int WishlistId { get; set; }
    }
}

