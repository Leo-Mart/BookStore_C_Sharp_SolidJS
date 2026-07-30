using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Users
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; } = string.Empty;
        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = null!;
        public DateTime Expires { get; set; }
        public DateTime? Revoked { get; set; }

        [NotMapped]
        public bool IsActive => Revoked is null && DateTime.UtcNow < Expires;
    }
}
