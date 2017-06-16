using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        public Repo()
        {
            _context = new EllosOldBoysContext();
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
            _context.Entry(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set.ToList();
        }

        public TEntity Find(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate,
            params string[] includeProperties)
        {
            return GetAllIncluding(includeProperties).Where(predicate).ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).Where(predicate).ToList();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _set.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> AllInclude(params string[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _set.Update(entity);
            _context.SaveChanges();
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = _set as IQueryable<TEntity>;

            return includeProperties.Aggregate
                (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        private IQueryable<TEntity> GetAllIncluding(params string[] includeProperties)
        {
            var queryable = _set as IQueryable<TEntity>;

            return includeProperties.Aggregate
                (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}