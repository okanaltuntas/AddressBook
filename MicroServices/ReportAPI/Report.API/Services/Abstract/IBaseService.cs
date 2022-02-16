﻿using Report.API.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Report.API.Services.Abstract
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter = null);
    }
}
