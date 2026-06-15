using System.ComponentModel.DataAnnotations;
using BookStore.Models.Authors;
using BookStore.Models.Genres;
using BookStore.Models.Inventories;
using BookStore.Models.OrderItems;
using BookStore.Models.Reviews;

namespace BookStore.Models.Books
{
    public class Book : BaseEntity
    {
        [Required]
        public string Isbn { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string? Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? CoverImageUrl { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public Inventory Inventory { get; set; } = null!;
        public ICollection<OrderItem> OrderItems {get;set;} = new List<OrderItem>();

    }
}