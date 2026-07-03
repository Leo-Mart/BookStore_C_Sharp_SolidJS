namespace BookStore.Models.ShippingMethods
{
    public record ShippingMethodInfoDto
    {
        public string Identifier { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}