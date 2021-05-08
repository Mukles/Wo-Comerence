using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._User;
using WebApplication2.ViewModel.Account;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wocomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        // POST: api/<AccountController>/Mokles
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.FristName.Trim() + model.LastName.Trim(),
                    CityName = model.City,
                    PhoneNumber = model.Mobile,
                    Gender = model.Gender,
                    DateOfBrith = model.DateOfBrith
                };

                var IsCreated = await userManager.CreateAsync(user, model.Password);
                if (IsCreated.Succeeded)
                {
                    await signInManager.SignInAsync(user, true);
                    return Ok("Account Create successfully");
                }
                else
                {
                    foreach(var err in IsCreated.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }

            var error = ModelState.Select(x => x.Value.Errors).Where(y => y.Count() > 0).ToList();
            return BadRequest(error);
        }

        // POST: api/<AccountController>/LogIn
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email };
                await signInManager.PasswordSignInAsync(user, model.Password, true, false);
            }

            return BadRequest(ModelState.ToDictionary(
      kvp => kvp.Key,
      kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
    ));
        }
    }
}
