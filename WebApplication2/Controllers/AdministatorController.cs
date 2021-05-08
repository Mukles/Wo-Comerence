using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wocomerce.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wocomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministatorController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministatorController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // POST: api/<AdministatorController>/AddAdmin
       /* [HttpPost]
        public async void AddAdmin([FromBody] AddClasimsViewModel model)
        {
            IdentityRole role = new IdentityRole { Name = model.RollName };
            IdentityResult result = await roleManager.CreateAsync(role);
        }*/

    }
}
