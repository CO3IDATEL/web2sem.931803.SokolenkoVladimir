using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class SignUpViewModel
    {
        [Required(                      ErrorMessage = "Please enter your first name!")]
        public String FirstName         { get; set; }

        [Required(                      ErrorMessage = "Please enter your second name!")]
        public String SecondName        { get; set; }

        [Required]
        public DateTime DateOfBirth     { get; set; }

        public Int32? Day                { get; set; }

        public Int32? Month              { get; set; }

        public Int32? Year               { get; set; }

        [Required(                      ErrorMessage = "Please select a gender!"        )]
        [Range(1, 2,                    ErrorMessage = "Please select a correct gender!")]
        public Gender Gender            { get; set; }
    }
}
