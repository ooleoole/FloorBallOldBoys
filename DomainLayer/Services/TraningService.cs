using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DomainLayer.Entities;
using DomainLayer.Interfaces;

namespace DomainLayer.Services
{
    public  class TraningService:ITraningService
    {
        private readonly IRepo<Traning> _repo;

        public TraningService(IRepo<Traning> repo)
        {
            _repo = repo;
        }

        public void Add(Traning traning)
        {
            _repo.Add(traning);
        }

        public IEnumerable<Traning> GetAll()
        {
            return _repo.GetAll();
        }

        public Traning Find(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Traning> FindAll(Expression<Func<Traning, bool>> predicate)
        {
            return _repo.FindAll(predicate);
        }

        public IEnumerable<Traning> AllInclude(params Expression<Func<Traning, object>>[] predicate)
        {
            return _repo.AllInclude(predicate);
        }

        public void Update(Traning traning)
        {
            _repo.Update(traning);
        }

        public IEnumerable<Traning> ChainInclude<TChain>(Expression<Func<Traning, object>> includeProperty, 
            Expression<Func<TChain, object>> chainedProprty)
        {
           return _repo.ChainInclude(includeProperty, chainedProprty);
        }
    }
}
