using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Addresses;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
  public class AddressRepository(ApplicationDbContext context) : IAddressRepository
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<bool> AddressExistsAsync(int addressId)
    {
      return await _context.Addresses.AnyAsync(a => a.Id == addressId);
    }

    public async Task<Address> CreateNewAddressAsync(Address address)
    {
      address.CreatedAt = DateTime.UtcNow;
      address.UpdatedAt = DateTime.UtcNow;
      await _context.Addresses.AddAsync(address);
      await _context.SaveChangesAsync();

      return address;
    }

    public async Task<Address?> GetAddressByIdAsync(int addressId)
    {
      return await _context.Addresses.Where(a => a.Id == addressId).FirstOrDefaultAsync();
    }

    public async Task<ICollection<AddressInfoDto>?> GetAddressesForUserAsync(string userId)
    {
      return await _context.Addresses
        .Where(a => a.AppUserId == userId)
        .Select(a => new AddressInfoDto
        {
          Street = a.Street,
          City = a.City,
          PostalCode = a.PostalCode,
          IsDefault = a.IsDefault
        }).ToListAsync();
    }

    public async Task<Address?> MarkAddressAsDefault(int addressId)
    {
      var addressFromDB = await _context.Addresses.Where(a => a.Id == addressId).FirstOrDefaultAsync();
      if (addressFromDB == null)
      {
        return null;
      }

      if (addressFromDB.IsDefault == true)
      {
        //TODO: send back a proper "this address is already the default" or similar error
        return null;
      }

      addressFromDB.IsDefault = true;
      addressFromDB.UpdatedAt = DateTime.UtcNow;
      await _context.SaveChangesAsync();

      return addressFromDB;
    }
  }
}