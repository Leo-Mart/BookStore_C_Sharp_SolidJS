using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.PaymentMethods;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
  public class PaymentMethodRepository(ApplicationDbContext context) : IPaymentMethodRepository
  {

    private readonly ApplicationDbContext _context = context;
    public async Task<PaymentMethod> CreateNewPaymentMethodAsync(PaymentMethod paymentMethod)
    {
        paymentMethod.CreatedAt = DateTime.UtcNow;
        paymentMethod.UpdatedAt = DateTime.UtcNow;

        await _context.PaymentMethods.AddAsync(paymentMethod);
        await _context.SaveChangesAsync();

        return paymentMethod;
    }

    public async Task<bool> PaymentMethodExistsAsync(int paymentMetodId)
    {
      return await _context.PaymentMethods.AnyAsync(pm => pm.Id == paymentMetodId);
    }
  }
}