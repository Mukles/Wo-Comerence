using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication2.repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity Entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Get(TEntity Entity);
        TEntity Find(int id);
        void Remove(TEntity T);
    }
}
