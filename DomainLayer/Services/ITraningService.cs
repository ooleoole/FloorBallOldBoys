using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DomainLayer.Entities;

namespace DomainLayer.Services
{
    public interface ITraningService
    {
        void Add(Traning traning);
        IEnumerable<Traning> GetAll();
        Traning Find(int id);
        IEnumerable<Traning> FindAll(Expression<Func<Traning, bool>> predicate);
        IEnumerable<Traning> AllInclude(params Expression<Func<Traning, object>>[] predicate);
        void Update(Traning traning);

        IEnumerable<Traning> ChainInclude<TChain>(Expression<Func<Traning, object>> includeProperty,
            Expression<Func<TChain, object>> chainedProprty);

    }
}
