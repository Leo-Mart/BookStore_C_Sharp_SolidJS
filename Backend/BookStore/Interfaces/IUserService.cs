using BookStore.Models.Addresses;
using BookStore.Models.Reviews;
using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IUserService
    {
        Task<CustomerDto?> GetCustomerInfo(string userId);
        Task<CustomerDto?> GetCustomerOrders(string userId);
        Task<CustomerDto?> GetCustomerWishlists(string userId);
        Task<CustomerDto?> GetCustomerAddresses(string userId);
        Task<AddressInfoDto?> GetCustomerDefaultAddress(string userId);
        Task<IEnumerable<ReviewInfoDto>?> GetCustomerReviews(string userId);
    }
}
