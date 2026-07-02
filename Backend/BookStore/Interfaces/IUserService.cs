using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IUserService
    {
        Task<CustomerDto?> GetCustomerInfo(string userId);
    }
}