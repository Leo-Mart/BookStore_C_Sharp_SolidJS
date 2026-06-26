namespace BookStore.Models.PaymentMethods
{
    public class CreatePaymentMethodDto
    {
        public string Type { get; set; } = string.Empty;
        public string CardLastFour { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty; // big nono at the very least hash/salt encrypt
        public int CVV { get; set; }
        public string ExpiryDate { get; set; } = string.Empty;

    }
}