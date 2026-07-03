namespace BookStore.Models.Wishlists
{
    public record WishlistItemInfoDto
    {
        public int BookId { get; set; }
        public int WishListId { get; set; }
    }
}