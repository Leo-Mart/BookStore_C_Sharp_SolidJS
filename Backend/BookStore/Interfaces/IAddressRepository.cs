using BookStore.Models.Addresses;

namespace BookStore.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateNewAddressAsync(Address address);
        Task<IEnumerable<Address>> GetAddressesForUserAsync(string userId);
        Task<Address> GetAddressByIdAsync(int addressId);
        Task<bool> AddressExistsAsync(int addressId);
    }
}