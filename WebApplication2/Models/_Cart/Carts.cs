using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Product;

namespace WebApplication2.Models._Cart
{
    public class Carts
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public List<Products> Products { get; set; }
    }
}
