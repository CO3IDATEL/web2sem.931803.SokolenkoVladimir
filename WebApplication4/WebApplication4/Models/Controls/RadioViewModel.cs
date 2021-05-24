using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.Controls
{
    public class RadioViewModel
    {
        [Required]
        public Int32? Month { get; set; }
    }
}