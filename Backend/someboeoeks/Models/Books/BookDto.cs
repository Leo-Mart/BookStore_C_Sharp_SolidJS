using someboeoeks.Models.Authors;
using someboeoeks.Models.Genres;
using someboeoeks.Models.Reviews;

namespace someboeoeks.Models.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Isbn {get;set;} = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CoverImageUrl { get; set; }
        public ICollection<ReviewDto> Reviews {get;set;} = new List<ReviewDto>();
        public ICollection<AuthorDto> Authors {get; set;} = new List<AuthorDto>();
        public ICollection<GenreDto> Genres {get; set;} = new List<GenreDto>();
        
    }
}