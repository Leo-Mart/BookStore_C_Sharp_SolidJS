using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace someboeoeks.Models.Books
{
    public class BookWithoutReviewsDto
    {
        public int Id { get; set; }
        public string Isbn {get;set;} = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}