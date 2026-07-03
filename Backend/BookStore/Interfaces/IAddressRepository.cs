using BookStore.Models.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateNewAddressAsync(Address address);
        Task<ICollection<AddressInfoDto>?> GetAddressesForUserAsync(string userId);
        Task<Address?> GetAddressByIdAsync(int addressId);
        Task<Address?> MarkAddressAsDefault(int addressId);
        Task<bool> AddressExistsAsync(int addressId);
    }
}