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
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Discription { get; set; }

        [Required]
        public float RegularPrice { get; set; }

        [Required]
        public float SalePrice { get; set; }

        [Required]
        public IFormFile ProductImage { get; set; }

        public List<IFormFile> Photos { get; set; }

    }
}
