using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Find(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties);
        void Delete(TEntity entity);
        IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> AllInclude(params string[] includeProperties);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate,
            params string[] includeProperties);

        void Update(TEntity entity);
    }
}