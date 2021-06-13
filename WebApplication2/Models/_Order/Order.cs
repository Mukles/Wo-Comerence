using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Product;
using WebApplication2.Models._User;

namespace WebApplication2.Models._Order
{
    public class Order
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Order_Date { get; set; }
        public List<Products> Products { get; set; } = new List<Products>();
    }
}
