using BookStore.Models.Addresses;

namespace BookStore.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateNewAddressAsync(Address address);
        Task<ICollection<AddressInfoDto>?> GetAddressesForUserAsync(string userId);
        Task<Address> GetAddressByIdAsync(int addressId);
        Task<bool> AddressExistsAsync(int addressId);
    }
}