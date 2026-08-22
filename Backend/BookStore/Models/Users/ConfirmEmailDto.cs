namespace BookStore.Models.Users
{
    public record ConfirmEmailDto
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
