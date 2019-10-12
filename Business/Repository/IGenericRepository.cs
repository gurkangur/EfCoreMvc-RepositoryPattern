using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        bool Remove(T entity);
        List<T> GetAll();
        List<T> GetWhere(Expression<Func<T, bool>> predicate);

    }
}
