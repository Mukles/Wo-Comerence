using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._User;
using Wocomerce.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wocomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministatorController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministatorController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

       
        public async void AddRole(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            if ((await userManager.IsInRoleAsync(user, "admin")))
            {
                await userManager.AddClaimAsync(user, new);
            }
        }
    }
}
