using System.ComponentModel.DataAnnotations;

namespace someboeoeks.Models.Users
{
    public class ReviewUserInfoDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
    }
}