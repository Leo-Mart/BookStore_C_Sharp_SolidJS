using BookStore.Models.Inventories;

namespace BookStore.Interfaces
{
    public interface IInventoryRepository
    {
        public Task<Inventory> CreateNewInventoryAsync(Inventory inventory);
        public Task<Inventory> IncreaseInventoryStockLevelAsync(int amount, int inventoryId);
        public Task<Inventory> DecreaseInventoryStockLevelAsync(int amount, int inventoryId);
        public Task<bool> InventoryExistsAsync(int inventoryId);

    }
}