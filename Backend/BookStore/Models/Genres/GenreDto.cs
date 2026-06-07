using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Genres
{
    public class GenreDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}