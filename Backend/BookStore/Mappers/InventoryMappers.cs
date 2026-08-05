using BookStore.Models.Inventories;

namespace BookStore.Mappers
{
    public static class InventoryMappers
    {
        public static InventoryInfoDto ToInventoryInfoDto(this Inventory inventory)
        {
            return new InventoryInfoDto { AmountInStock = inventory.AmountInStock };
        }
    }
}
