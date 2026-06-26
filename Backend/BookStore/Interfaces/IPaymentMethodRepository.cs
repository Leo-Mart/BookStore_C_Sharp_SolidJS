using BookStore.Models.PaymentMethods;

namespace BookStore.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> CreateNewPaymentMethodAsync(PaymentMethod paymentMethod);
        Task<bool> PaymentMethodExistsAsync(int paymentMetodId);
    }
}