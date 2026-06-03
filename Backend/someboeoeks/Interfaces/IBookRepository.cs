using someboeoeks.Models.Books;
using someboeoeks.Services;

namespace someboeoeks.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<(IEnumerable<Book>, PaginationMetaData)> GetBooksAsync(string? title, string? searchQuery, int pageNumber, int pageSize);
        Task<Book?> GetBookByIdAsync(int bookId);
        Task<bool> BookExistsAsync(int bookId);


    }
}