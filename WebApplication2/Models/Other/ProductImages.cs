using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Product;

namespace WebApplication2.Models.Other
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Products Products { get; set; }
        public int ProductId { get; set; }
    }

}
