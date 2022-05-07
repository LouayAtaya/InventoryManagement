using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InventoryManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<T> FindAll() => this._dbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._dbContext.Set<T>().Where(expression);
        }

        public void Create(T entity) => this._dbContext.Set<T>().Add(entity);

        public void Update(T entity) => this._dbContext.Set<T>().Update(entity);

        public void Delete(T entity) => this._dbContext.Set<T>().Remove(entity);

    }
}
