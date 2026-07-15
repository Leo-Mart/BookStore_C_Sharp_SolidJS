using BookStore.Models.Books;

namespace BookStore.Models.OrderItems
{
    public record OrderItemInfoDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public BookItemInfoDto BookInfo { get; set; } = null!;
    }
}