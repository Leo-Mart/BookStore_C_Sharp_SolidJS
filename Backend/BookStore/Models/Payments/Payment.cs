using BookStore.Models.Orders;
using BookStore.Models.PaymentMethods;

namespace BookStore.Models.Payments
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        // public string TransactionId {get;set;}
        public DateTime PaymentDate { get; set; }

        public Order Order { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
    }
}