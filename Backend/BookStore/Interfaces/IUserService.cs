using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IUserService
    {
        Task<CustomerDto?> GetCustomerInfo(string userId);
        Task<CustomerDto?> GetCustomerOrders(string userId);
        Task<CustomerDto?> GetCustomerWishlists(string userId);
        Task<CustomerDto?> GetCustomerAddresses(string userId);
    }
}

