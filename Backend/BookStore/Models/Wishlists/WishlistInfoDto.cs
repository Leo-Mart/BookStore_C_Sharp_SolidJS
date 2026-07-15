namespace BookStore.Models.Wishlists
{
    public record WishlistInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public string? Description { get; set; }
        public ICollection<WishlistItemInfoDto> WishlistItems { get; set; } = new List<WishlistItemInfoDto>();
    }
}