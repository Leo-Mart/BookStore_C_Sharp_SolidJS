using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Users
{
    public record ForgottenPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
