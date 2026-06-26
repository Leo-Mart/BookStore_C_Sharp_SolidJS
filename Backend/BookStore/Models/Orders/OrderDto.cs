using System.ComponentModel.DataAnnotations;
using BookStore.Models.OrderItems;

namespace BookStore.Models.Orders
{
    public class OrderDto
    {
        public string AppUserId { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        [Required]
        public decimal OrderTotalCost { get; set; }
        public ICollection<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}