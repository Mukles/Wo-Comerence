using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Helpers;
using WebApplication2.Models._Account;
using WebApplication2.Models._Product;
using WebApplication2.Models.Other;
using WebApplication2.repository.Product;
using Wocomerce.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wocomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ProductRepository productRepository;
        private readonly ImgProcesing imgProcesing;

        public ProductsController(AppDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment )
        {
            this.context = context;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
            productRepository = new ProductRepository(context);
            imgProcesing = new ImgProcesing(webHostEnvironment);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Products);
        }

        
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromForm] AddProduct Entity) 
        {
            var Product = mapper.Map<Products>(Entity);
            Product.ProductImage = imgProcesing.ImageProcesing(Entity.ProductImage);
            Entity.Photos.ForEach(image => Product.photos.Add(new ProductImages { FileName = imgProcesing.ImageProcesing(image)}));
            productRepository.Add(Product);
            productRepository.Complete();
            return Ok();
        }
    }
}
