using BookStore.Models.Orders;
using BookStore.Models.Users;

namespace BookStore.Models.Addresses
{
    public class Address : BaseEntity
    {
        public string? AppUserId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public AppUser? AppUser { get; set; } = null;
        public ICollection<Order> Orders { get; set; } = null!;
    }
}