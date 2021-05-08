using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Product;
using Wocomerce.Models;

namespace WebApplication2.repository.Product
{
    public class ProductRepository:Repository<Products>
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context): base(context)
        {
            this.context = context;
        }
    }
}
