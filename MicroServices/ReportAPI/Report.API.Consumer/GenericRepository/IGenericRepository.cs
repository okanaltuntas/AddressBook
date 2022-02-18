using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Report.API.Model;

namespace Report.API.GenericRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
        Task<bool> SaveAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter = null);
        IQueryable<T> Queryable();
        bool AddBulk(List<T> entities);
        bool DeleteBulk(List<T> entities);
    }
}
