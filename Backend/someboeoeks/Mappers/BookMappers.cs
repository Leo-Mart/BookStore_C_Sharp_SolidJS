using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using someboeoeks.Models.Books;

namespace someboeoeks.Mappers
{
    public static class BookMappers
    {
        public static BookWithoutReviewsDto ToBookWithoutReviewsDto(this Book bookModel)
        {
            return new BookWithoutReviewsDto
            {
                Id = bookModel.Id,
                Isbn = bookModel.Isbn,
                Title = bookModel.Title,
                Publisher = bookModel.Publisher,
                PublishedDate = bookModel.PublishedDate,
                Description = bookModel.Description,
                Price = bookModel.Price,
                CoverImageUrl = bookModel.CoverImageUrl,
            };
        }

        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Isbn = bookModel.Isbn,
                Title = bookModel.Title,
                Publisher = bookModel.Publisher,
                PublishedDate = bookModel.PublishedDate,
                Description = bookModel.Description,
                Price = bookModel.Price,
                CoverImageUrl = bookModel.CoverImageUrl,
                Reviews = bookModel.Reviews.Select(r => r.ToReviewDto()).ToList(),
                Authors = bookModel.Authors.Select(r => r.ToAuthorDto()).ToList(),
                Genres = bookModel.Genres.Select(r => r.ToGenreDto()).ToList()                
            };
        }
    }
}