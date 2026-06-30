using BookStore.Models.Orders;

namespace BookStore.Models.ShippingMethods
{
    public class ShippingMethod : BaseEntity
    {
        public string Company { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();


    }
}