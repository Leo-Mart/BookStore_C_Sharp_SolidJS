namespace BookStore.Models.Wishlists
{
    public record WishlistItemInfoDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int WishlistId { get; set; }
    }
}