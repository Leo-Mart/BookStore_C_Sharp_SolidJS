using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using someboeoeks.Models.Books;

namespace someboeoeks.Models.Authors
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public string? Bio { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}