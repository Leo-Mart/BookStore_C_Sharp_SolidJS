using System.ComponentModel.DataAnnotations;
using someboeoeks.Models.Authors;
using someboeoeks.Models.Genres;
using someboeoeks.Models.Reviews;

namespace someboeoeks.Models.Books
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
        public ICollection<Author> Authors {get; set;} = new List<Author>();
        public ICollection<Genre> Genres {get; set;} = new List<Genre>();

    }
}