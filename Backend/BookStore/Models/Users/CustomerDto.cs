using BookStore.Models.Addresses;
using BookStore.Models.Orders;
using BookStore.Models.Reviews;
using BookStore.Models.Wishlists;

namespace BookStore.Models.Users
{
    public class CustomerDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email {get;set;} = string.Empty;
        public ICollection<ReviewInfoDto> Reviews { get; set; } = new List<ReviewInfoDto>();
        public ICollection<OrderInfoDto> Orders { get; set; } = new List<OrderInfoDto>();
        public ICollection<AddressInfoDto> Addresses { get; set; } = new List<AddressInfoDto>();
        public ICollection<WishlistInfoDto> Wishlits {get;set;} = new List<WishlistInfoDto>();
    }
}