using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Product;
using Wocomerce.Models;

namespace WebApplication2.repository.Order
{
    public class OrderRepository: Repository<WebApplication2.Models._Order.Order>
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context): base(context)
        {
            this.context = context;
        }

        public Products FindProduct(int Id)
        {
            return context.Products.Find(Id);
        }

        public void Find(string userName)
        {
        }
        public void AddOrder(int ProductId)
        {
            var product = context.Products.Find(ProductId);
            product.Order.Products.Add()
            var order = new WebApplication2.Models._Order.Order();
            order.Products.Add()
            context.Orders.Add()
        }
    }
}
