using BookStore.Models.Books;
using BookStore.Services;

namespace BookStore.Interfaces
{
    public interface IFindServce
    {
        Task<(IEnumerable<Book>, PaginationMetaData)> SearchForBooks(
            string? searchQuery,
            int pageNumber,
            int pageSize
        );
    }
}
