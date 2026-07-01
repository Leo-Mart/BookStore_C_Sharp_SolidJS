using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.ShippingMethods;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
  public class ShippingMethodRepository(ApplicationDbContext context) : IShippingMethodRepository
  {
    private readonly ApplicationDbContext _context = context;
    public async Task<IEnumerable<ShippingMethod>> GetShippingMethodsAsync()
    {
      return await _context.ShippingMethods.ToListAsync();
    }

    public async Task<ShippingMethod?> GetShippingMethodByIdentifierAsync(string identifier)
    {
      return await _context.ShippingMethods.Where(sm => sm.Identifier == identifier).FirstOrDefaultAsync();
    }
  }
}