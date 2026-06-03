using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using someboeoeks.Models.Users;

namespace someboeoeks.Models.Reviews
{
    public class UpdateReviewDto
    {
        [Required(ErrorMessage = "A title is required.")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Text { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}