using BookStore.Models.ShippingMethods;

namespace BookStore.Interfaces
{
    public interface IShippingMethodRepository
    {
        Task<IEnumerable<ShippingMethod>> GetShippingMethodsAsync();
    }
}