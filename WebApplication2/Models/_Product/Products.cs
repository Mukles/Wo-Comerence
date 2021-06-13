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
            photos = new List<ProductImages>();
        }

        public int Id { get; set; }

        [Column("Name")]
        public string ProductName { get; set; }

        [Column("Price")]
        public float Price { get; set; }

        [Column("Images")]
        public List<ProductImages> photos { get; set; }

        [Column("Product_Image")]
        public string ProductImage { get; set; }
        [Column("Discount")]
        public float Discount { get; set; }

        public int CartId { get; set; }
        public Carts Carts { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public string Discription { get; set; }
    }
}
