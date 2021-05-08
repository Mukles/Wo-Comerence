using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Other;

namespace WebApplication2.Models._Account
{
    public class Register
    {
        public string FristName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Mobile { get; set; }

        public string City { get; set; }

        public DateTime DateOfBrith { get; set; }
    }
}
