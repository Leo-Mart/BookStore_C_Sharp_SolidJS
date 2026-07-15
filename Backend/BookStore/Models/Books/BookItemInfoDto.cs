using BookStore.Models.Authors;

namespace BookStore.Models.Books
{
    public class BookItemInfoDto
    {
        public string Isbn { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CoverImageUrl { get; set; }
        public ICollection<AuthorDto> Authors { get; set; } = new List<AuthorDto>();

    }
}