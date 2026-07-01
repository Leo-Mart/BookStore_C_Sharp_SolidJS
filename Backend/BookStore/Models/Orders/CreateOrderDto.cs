using System.ComponentModel.DataAnnotations;
using BookStore.Models.Addresses;
using BookStore.Models.OrderItems;
using BookStore.Models.PaymentMethods;
using BookStore.Models.ShippingMethods;

namespace BookStore.Models.Orders
{
    public class CreateOrderDto
    {
        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        [Required]
        public decimal OrderTotalCost { get; set; }
        public string? GuestEmail { get; set; }
        public CreateAddressDto Address { get; set; } = null!;
        public ShippingMethod ShippingMethod { get; set; } = null!;
        public CreatePaymentMethodDto PaymentMethod { get; set; } = null!;
        [Required]
        public ICollection<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();

    }
}