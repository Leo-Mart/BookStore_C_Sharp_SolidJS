using System.ComponentModel.DataAnnotations;
using BookStore.Models;
using BookStore.Models.Books;

namespace BookStore.Models.Genres
{
    public class Genre : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}