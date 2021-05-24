using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ResetCodeVerificationViewModel : ResetViewModel
    {
        [Required]
        public String Code { get; set; }
    }
}