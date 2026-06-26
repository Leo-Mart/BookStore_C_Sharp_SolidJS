using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class PaymentRepository(ApplicationDbContext context) : IPaymentRepository
    {
        private readonly ApplicationDbContext _context = context;

    public async Task<Payment> CreateNewPaymentAsync(Payment payment)
    {
        payment.CreatedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        return payment;
    }

    public async Task<bool> PaymentExistsAsync(int paymentId)
    {
      return await _context.Payments.AnyAsync(p => p.Id == paymentId);
    }
  }
}