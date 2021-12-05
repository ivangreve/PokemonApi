using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Challenge.Models.Repositories
{
    public interface IAsyncDbRepository<T>
    {
        void Add(T entity);
        Task SaveAsync();
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    }
}
