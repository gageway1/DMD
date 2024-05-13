using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Data.Repositories.Base
{
    public class Repository<T>(DMDContext context) : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> filter,
                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            query = query.Where(filter);

            if (orderBy != null)
            {
                _ = orderBy(query);
            }
            return query;
        }

        public async Task<IQueryable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
            => orderBy != null ? orderBy(_dbSet) : _dbSet;
    }
}
