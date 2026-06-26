namespace BookStore.Models.Users
{
    public class NewUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Token {get; set;} = string.Empty;
    }
}