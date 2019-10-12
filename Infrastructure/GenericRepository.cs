using Business.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected DataDbContext Context;

        public GenericRepository(DataDbContext context)
        {
            Context = context;
        }

        public T Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChangesAsync();
            return entity;
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public bool Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }
    }
}
