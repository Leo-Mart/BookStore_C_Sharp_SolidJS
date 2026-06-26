namespace BookStore.Models.Addresses
{
    public class CreateAddressDto
    {
        
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}