using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Order;
using WebApplication2.Models._User;
using WebApplication2.repository.Order;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(OrderRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string UserId)
        {
            var user = await userManager.FindByEmailAsync(UserId);
            if (user == null) return NotFound();
            return Ok(user.Orders);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int ProductId,string userId)
        {
            var Product = repository.FindProduct(ProductId);
            var user = await userManager.FindByEmailAsync(userId);
           
            if(Product != null && user != null)
            {
                user.Orders.Products.Add(Product);
                repository.Complete();
                return Ok();
            }

            return NotFound();
        }
    }
}
