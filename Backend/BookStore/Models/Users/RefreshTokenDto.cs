using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Users
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
