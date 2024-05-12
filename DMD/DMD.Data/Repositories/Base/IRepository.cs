using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Data.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
                          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
        Task<IQueryable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    }
}
