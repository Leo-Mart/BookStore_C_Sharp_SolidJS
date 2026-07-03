using BookStore.Models.OrderItems;
using BookStore.Models.ShippingMethods;

namespace BookStore.Models.Orders
{
    public record OrderInfoDto
    {
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public decimal OrderTotalCost { get; set; }
        public ShippingMethodInfoDto ShippingMethod { get; set; } = null!;
        public ICollection<OrderItemInfoDto> Items { get; set; } = new List<OrderItemInfoDto>();
    }
}