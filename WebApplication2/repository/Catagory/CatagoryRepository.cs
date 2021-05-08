using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Catagory;
using WebApplication2.Models._Catagory.Sub_Catagory;
using Wocomerce.Models;

namespace WebApplication2.repository._Catagory
{
    public class CatagoryRepository : Repository<Catagory>
    {
        private readonly AppDbContext context;

        public CatagoryRepository(AppDbContext context): base(context)
        {
            this.context = context;
        }

        public Catagory FindByName(string Name)
        {
            return context.Catagory.Single(c => c.catagoryName == Name);
        }

        public IEnumerable<Catagory> Entities()
        {
            return context.Catagory.Include(c => c.SubCatagories).ToList();
        }
    }
}
