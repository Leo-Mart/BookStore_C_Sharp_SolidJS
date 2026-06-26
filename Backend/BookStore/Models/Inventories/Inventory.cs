using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Models.Books;


namespace BookStore.Models.Inventories
{
    public class Inventory : BaseEntity
    {
        [Required]
        public int BookId {get;set;}
        [Required]
        public int AmountInStock {get;set;} =0;
        [Required]
        public int ReorderThreshold {get;set;} = 5;
        public Book Book {get;set;} = null!;
        [NotMapped]
        public bool TimeToRefillStock => AmountInStock <= ReorderThreshold;
    }
}