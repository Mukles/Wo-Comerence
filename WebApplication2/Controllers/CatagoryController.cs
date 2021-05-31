using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Catagory;
using WebApplication2.Models._Catagory.Sub_Catagory;
using WebApplication2.repository._Catagory;
using WebApplication2.ViewModel.Catagory;
using Wocomerce.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CatagoryController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly CatagoryRepository catagoryRepository;

        public CatagoryController(AppDbContext context)
        {
            catagoryRepository = new CatagoryRepository(context);
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(catagoryRepository.Entities());
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] AddCatagory Entity)
        {
            var catagory = new Catagory();
            if(string.IsNullOrEmpty(Entity.ParentCatagory) || string.IsNullOrWhiteSpace(Entity.ParentCatagory))
            {
                catagory = new Catagory { catagoryName = Entity.CatagoryName };
                catagoryRepository.Add(catagory);
                catagoryRepository.Complete();
                return Ok(catagory);
            }
            else
            {
                var catagories = context.Catagory.ToList();
                catagory = catagoryRepository.FindByName(Entity.ParentCatagory);
                catagory.SubCatagories.Add(new SubCatagory { SubCatgoriesName = Entity.CatagoryName });
                catagoryRepository.Complete();
                return Ok(catagory);
            }
        }

    }
}
