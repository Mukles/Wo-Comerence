using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models._User;
using WebApplication2.Models.Configuration;
using WebApplication2.ViewModel.Account;
using System.Security.Claims;

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
        private readonly JwtConfig _jwtConfig;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IMapper mapper,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        // POST: api/<AccountController>/Mokles
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser NewUser = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FristName = model.FristName,
                    LastName = model.LastName,
                    CityName = model.City,
                    PhoneNumber = model.Mobile,
                    Gender = model.Gender,
                    DateOfBrith = model.DateOfBrith
                };

                var IsCreated = await userManager.CreateAsync(NewUser, model.Password);
                if (IsCreated.Succeeded)
                {
                    await signInManager.SignInAsync(NewUser, true);
                    var jwtToken = GenerateJwtToken(NewUser);
                    return Ok(new AuthResult { Success = true, Token = jwtToken });
                }
                else
                {
                    foreach(var err in IsCreated.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }
                }
            }

            var error = ModelState.ToDictionary(key => key.Key, value => value.Value.Errors.Select(e => e.ErrorMessage));
            return BadRequest(new AuthResult { Success = false, Erros = error});
        }

        // POST: api/<AccountController>/LogIn
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email };
                await signInManager.PasswordSignInAsync(user, model.Password, true, false);
                var jwtToken = GenerateJwtToken(user);
                return Ok(new AuthResult { Success = true, Token = jwtToken });
            }

            return BadRequest(new AuthResult { Success = true, Erros = "Invalid Login attempt" });
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
