using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wocomerce.Models;

namespace WebApplication2.repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity Entity)
        {
            context.Set<TEntity>().Add(Entity);
        }

        public TEntity Find(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get(TEntity Entity)
        {
            return context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity Entity)
        {
            context.Set<TEntity>().Remove(Entity);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression);
        }
    }
}
