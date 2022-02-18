using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Report.API.Model;
using EFCore.BulkExtensions;

namespace Report.API.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly AppDbContext db = new AppDbContext();
        readonly DbSet<T> context;

        public GenericRepository()
        {
            context = db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = false;
            context.Add(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                entity.IsDeleted = true;
                await UpdateAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await context.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await context.FindAsync(id);
        }

        public IQueryable<T> Queryable()
        {
            return context.AsQueryable();
        }

        public bool AddBulk(List<T> entities)
        {
            try
            {
                db.BulkInsert(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteBulk(List<T> entities)
        {
            try
            {
                db.BulkDelete(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter = null)
        {
            return await context.Where(filter).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return entity;
        }
    }
}
