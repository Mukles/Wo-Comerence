using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Account;
using WebApplication2.Models.Other;

namespace WebApplication2.ViewModel.Account
{
    public class RegisterModel
    {
        [Required]
        public string FristName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public DateTime DateOfBrith { get; set; }
    }
}
