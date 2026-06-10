using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Books;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
  public class BookRepository(ApplicationDbContext context) : IBookRepository
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<Book?> GetBookByIdAsync(int bookId)
    {
      return await _context.Books
        .Include(r => r.Reviews)
          .ThenInclude(r => r.Reviewer)
        .Include(g => g.Genres)
        .Include(a => a.Authors)
        .Where(c => c.Id == bookId)
        .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
      return await _context.Books.Include(a => a.Authors).ToListAsync();
    }

    public async Task<(IEnumerable<Book>, PaginationMetaData)> GetBooksAsync(string? title, string? searchQuery, int pageNumber, int pageSize)
    {

      var collection = _context.Books.Include(a => a.Authors) as IQueryable<Book>;

      if (!string.IsNullOrWhiteSpace(title))
      {
        title = title.Trim();
        collection = collection.Where(b => b.Title == title);
      }

      if (!string.IsNullOrWhiteSpace(searchQuery))
      {
        searchQuery = searchQuery.Trim();
        collection = collection.Where(a => a.Title.Contains(searchQuery) || (a.Description != null && a.Description.Contains(searchQuery)));
      }

      var totalItemCount = await collection.CountAsync();

      var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);

      var collectionToReturn = await collection.OrderBy(b => b.Title)
        .Skip(pageSize * (pageNumber - 1))
        .Take(pageSize)
        .ToListAsync();

      return (collectionToReturn, paginationMetaData);
    }

    public async Task<bool> BookExistsAsync(int bookId)
    {
      return await _context.Books.AnyAsync(b => b.Id == bookId);
    }
  }
}