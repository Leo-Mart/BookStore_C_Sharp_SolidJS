using System.ComponentModel.DataAnnotations;
using BookStore.Models.OrderItems;
using BookStore.Models.Users;

namespace BookStore.Models.Orders
{
    public class Order : BaseEntity
    {
        [Required]
        public string AppUserId {get;set;}
        public AppUser Customer {get;set;} = null!;

        [Required]
        public OrderStatus OrderStatus {get;set;} = OrderStatus.Pending;
        [Required]
        public decimal OrderTotalCost {get;set;}
        public ICollection<OrderItem> Items {get;set;} = new List<OrderItem>();



    }
}