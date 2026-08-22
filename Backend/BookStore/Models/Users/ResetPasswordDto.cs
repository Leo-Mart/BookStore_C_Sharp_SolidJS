using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Users
{
    public record ResetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
