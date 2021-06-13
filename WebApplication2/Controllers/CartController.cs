using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Cart;
using WebApplication2.Models._User;
using WebApplication2.repository.Cart;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(CartRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        
        [HttpPost]
        public async Task<IActionResult> Add(int ProductId, string UserId)
        {
            var user = await userManager.FindByEmailAsync(UserId);
            var product = repository.FindProduct(ProductId);
            if(user != null && product != null)
            {
                user.Cart.Products.Add(product);
                return Ok();
            }

            return NotFound();
        }
    }
}
