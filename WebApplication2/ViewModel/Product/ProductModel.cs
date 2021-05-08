using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Other;

namespace WebApplication2.ViewModel.Product
{
    public class ProductModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public List<IFormFile> photos { get; set; }

        [Required]
        public IFormFile ProductImage { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public float Discount { get; set; }

        [Required]
        public string Discription { get; set; }
    }
}
