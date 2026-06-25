using System.ComponentModel.DataAnnotations;
using BookStore.Models.Addresses;
using BookStore.Models.OrderItems;
using BookStore.Models.PaymentMethods;
using BookStore.Models.Users;

namespace BookStore.Models.Orders
{
    public class Order : BaseEntity
    {
        [Required]
        public string AppUserId { get; set; }
        public int AddressId { get; set; }
        public int PaymentMethodId {get;set;}

        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        [Required]
        public decimal OrderTotalCost { get; set; }
        public AppUser Customer { get; set; } = null!;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Address Address { get; set; } = null!;
        public PaymentMethod PaymentMethod {get;set;} = null!;
    }
}