using BookStore.Models.Books;
using BookStore.Services;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<(IEnumerable<Book>, PaginationMetaData)> GetBooksAsync(string? title, string? searchQuery, int pageNumber, int pageSize);
        Task<Book?> GetBookByIdAsync(int bookId);
        Task<bool> BookExistsAsync(int bookId);


    }
}