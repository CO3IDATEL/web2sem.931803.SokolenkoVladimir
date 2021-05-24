using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ResetViewModel
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
    }
}
