using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Models.Books;
using BookStore.Models.Orders;

namespace BookStore.Models.OrderItems
{
    public class OrderItem : BaseEntity
    {
        [Required]
        public int OrderId {get;set;}
        [Required]
        public int BookId {get;set;}
        [Required]
        public decimal UnitPrice {get;set;}
        [Required]
        public int Quantity {get;set;} = 1;
        public Order Order {get;set;} = null!;
        public Book Book {get;set;} = null!;
        [NotMapped]
        public decimal Subtotal => UnitPrice * Quantity;
        
    }
}