using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Users
{
    public class ResetPasswordDto
    {
        [Required]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
