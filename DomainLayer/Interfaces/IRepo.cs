﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DomainLayer.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {

        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        void Update(TEntity entity);

        IEnumerable<TEntity> ChainInclude<TChain>(Expression<Func<TEntity, object>> includeProperty,
            Expression<Func<TChain, object>>chainedProprty);
    }
}
