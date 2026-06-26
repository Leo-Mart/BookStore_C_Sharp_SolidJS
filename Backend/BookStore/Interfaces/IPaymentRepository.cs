using BookStore.Models.Payments;

namespace BookStore.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> CreateNewPaymentAsync(Payment payment);
        Task<bool> PaymentExistsAsync(int paymentId);
        
    }
}