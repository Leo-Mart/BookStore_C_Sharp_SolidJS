using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Inventories
{
    public class InventoryInfoDto
    {
        [Required]
        public int AmountInStock { get; set; } = 0;
    }
}
