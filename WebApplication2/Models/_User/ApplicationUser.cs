using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Cart;
using WebApplication2.Models._Order;
using WebApplication2.Models.Other;

namespace WebApplication2.Models._User
{
    public class ApplicationUser:IdentityUser
    {
        [Column("City_Name")]
        public string CityName { get; set; }

        [Column("Post_Code")]
        public int PostCode { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
        
        [Column("Date_Of_Brith")]
        public DateTime DateOfBrith { get; set; }

        public Order Orders { get; set; }

        public Carts Cart { get; set; }
    }
}
