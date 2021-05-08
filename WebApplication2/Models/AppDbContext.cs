
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Cart;
using WebApplication2.Models._Catagory;
using WebApplication2.Models._Order;
using WebApplication2.Models._Product;
using WebApplication2.Models._User;

namespace Wocomerce.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Products> Products { get; set; }

        public DbSet<Catagory> Catagory { get; set; }

        public DbSet<Carts> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
