using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Cart;
using WebApplication2.Models._Product;
using Wocomerce.Models;

namespace WebApplication2.repository.Cart
{
    public class CartRepository: Repository<Carts>
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context): base(context)
        {
            this.context = context;
        }
        public Products FindProduct(int Id)
        {
            return context.Products.Find(Id);
        }
    }
}
