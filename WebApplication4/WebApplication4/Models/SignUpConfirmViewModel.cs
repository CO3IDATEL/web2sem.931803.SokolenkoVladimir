using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class SignUpConfirmViewModel : SignUpFoundViewModel
    {
        [Required(                          ErrorMessage = "Please enter your email!"               )]
        [DataType(DataType.EmailAddress,    ErrorMessage = "Email should be in correct format!"     )]
        [EmailAddress(                      ErrorMessage = "Email should be in correct format!"     )]
        public String Email                 { get; set; }

        [Required(                          ErrorMessage = "Please enter your password!"            )]
        [DataType(DataType.Password,        ErrorMessage = "Password should be in correct format"   )]
        public String Password              { get; set; }

        [DataType(DataType.Password,        ErrorMessage = "Password should be in correct format"   )]
        [Compare("Password",                ErrorMessage = "Passwords don't match!"                 )]
        public String ConfirmPassword       { get; set; }

        [Required]
        public Boolean RememberMe           { get; set; } = false;

    }
}
