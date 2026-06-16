using BookStore.Models.Books;

namespace BookStore.Mappers
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
                Authors = bookModel.Authors.Select(a => a.ToAuthorDto()).ToList()
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

        public static BookOrderItemInfoDto ToBookOrderItemInfoDtoFromBook(this Book book)
        {
            return new BookOrderItemInfoDto
            {
                Id = book.Id,
                Price = book.Price
            };
        }
    }
}