using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wocomerce.Models
{
    public class AddProduct
    {
        public string ProductName { get; set; }

        public string Discription { get; set; }

        public float RegularPrice { get; set; }

        public float SalePrice { get; set; }

        public IFormFile ProductImage { get; set; }

        public List<IFormFile> Photos { get; set; }

        public WebApplication2.Models._Catagory.Catagory catagory { get; set; }

    }
}
