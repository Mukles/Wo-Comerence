using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Cart;
using WebApplication2.Models._Order;
using WebApplication2.Models._Ratings;
using WebApplication2.Models.Other;

namespace WebApplication2.Models._Product
{
    public class Products
    {
        public Products()
        {
            Carts = new List<Carts>();
            Orders = new List<Order>();
            photos = new List<ProductImages>();
        }

        public string Id { get; set; }

        [Column("Name")]
        public string ProductName { get; set; }

        [Column("Price")]
        public float Price { get; set; }

        [Column("Images")]
        public List<ProductImages> photos { get; set; }

        [Column("Ratings")]
        public List<Rating> Rating { get; set; }

        [Column("Discount")]
        public float Discount { get; set; }

        [Column("Cart")]
        public List<Carts> Carts { get; set; }

        [Column("Order")]
        public List<Order> Orders { get; set; }

        public string Discription { get; set; }
    }
}
