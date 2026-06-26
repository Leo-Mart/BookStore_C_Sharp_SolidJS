using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Inventories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
    {
        private readonly ApplicationDbContext _context = context;
        public Task<Inventory> CreateNewInventoryAsync(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public async Task<Inventory> DecreaseInventoryStockLevelAsync(int amount, int inventoryId)
        {
            var inventoryFromDb = await _context.Inventories.Where(i => i.Id == inventoryId).FirstOrDefaultAsync();

            if (inventoryFromDb == null)
            {
                return null;
            }

            if (amount > inventoryFromDb.AmountInStock)
            {
                return null; // TODO: handle this better,
            }

            inventoryFromDb.AmountInStock -= amount;
            if (inventoryFromDb.AmountInStock < 0)
            {
                inventoryFromDb.AmountInStock = 0;
                // TODO: and then handle some alert or similar to warn about stocklevel.
            }
            inventoryFromDb.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return inventoryFromDb;
        }

        public async Task<Inventory> IncreaseInventoryStockLevelAsync(int amount, int inventoryId)
        {
            var inventoryFromDb = await _context.Inventories.Where(i => i.Id == inventoryId).FirstOrDefaultAsync();

            if (inventoryFromDb == null)
            {
                return null;
            }

            inventoryFromDb.AmountInStock += amount;            
            inventoryFromDb.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return inventoryFromDb;
        }

        public Task<bool> InventoryExistsAsync(int inventoryId)
        {
            throw new NotImplementedException();
        }
    }
}