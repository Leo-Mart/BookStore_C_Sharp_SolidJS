using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Books;

namespace BookStore.Services
{
    public class FindServce(ILogger<FindServce> logger, IBookRepository booksRepo) : IFindServce
    {
        private readonly ILogger<FindServce> _logger = logger;
        private readonly IBookRepository _booksRepo = booksRepo;

        public async Task<(IEnumerable<Book>, PaginationMetaData)> SearchForBooks(
            string? searchQuery,
            int pageNumber,
            int pageSize
        )
        {
            var (books, paginationMetaData) = await _booksRepo.GetBooksAsync(
                searchQuery,
                pageNumber,
                pageSize
            );
            var bookDtos = books.Select(b => b.ToBookWithoutReviewsDto());

            return (books, paginationMetaData);
        }
    }
}
