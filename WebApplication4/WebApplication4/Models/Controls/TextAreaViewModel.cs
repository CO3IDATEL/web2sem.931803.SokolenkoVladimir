using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.Controls
{
    public class TextAreaViewModel
    {
        [Required]
        public String Text { get; set; }
    }
}