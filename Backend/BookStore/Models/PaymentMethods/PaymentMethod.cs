using BookStore.Models.Orders;
using BookStore.Models.Payments;
using BookStore.Models.Users;

namespace BookStore.Models.PaymentMethods
{
    public class PaymentMethod : BaseEntity
    {
        public string AppUserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string CardLastFour { get; set; } = string.Empty;
        // public string Brand { get; set; } = string.Empty;
        // public string Token {get;Set;} this is probably the real way to store the info, instead of the whole number in plaintext.
        public string CardNumber { get; set; } = string.Empty; // big nono at the very least hash/salt encrypt
        public int CVV { get; set; }
        public string ExpiryDate { get; set; } = string.Empty;
        public bool IsDefault { get; set; }

        public AppUser AppUser { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}