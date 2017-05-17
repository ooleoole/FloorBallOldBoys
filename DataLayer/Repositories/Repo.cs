using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Context;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Repositories
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _set;
        private readonly DbContext _context;

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
            return _set.Where(predicate);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }
        public void Update(TEntity entity)
        {
            _set.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public IEnumerable<TEntity> ChainInclude<TChain>(Expression<Func<TEntity, object>> includeProperty,
            Expression<Func<TChain, object>> chainedProprty)
        {

            return _set.Include(includeProperty).Include(includeProperty);
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = _set as IQueryable<TEntity>;

            return includeProperties.Aggregate
                (queryable, (current, includeProperty) => current.Include(includeProperty));
        }


    }


}
