
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.OrderItems
{
    public class OrderItemDto
    {
        public int OrderId {get;set;}
        [Required]
        public int BookId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
    }
}