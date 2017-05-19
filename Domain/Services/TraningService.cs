using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public  class TraningService:ITraningService
    {
        private readonly IRepo<Training> _repo;

        public TraningService(IRepo<Training> repo)
        {
            _repo = repo;
        }

        public void Add(Training training)
        {
            _repo.Add(training);
        }

        public IEnumerable<Training> GetAll()
        {
            return _repo.GetAll();
        }

        public Training Find(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate)
        {
            return _repo.FindAll(predicate);
        }

        public IEnumerable<Training> AllInclude(params Expression<Func<Training, object>>[] predicate)
        {
            return _repo.AllInclude(predicate);
        }

        public void Update(Training training)
        {
            _repo.Update(training);
        }

        public void Delete(Training training)
        {
            _repo.Delete(training);
        }

        public IEnumerable<Training> AllInclude(string includeProperties)
        {
            return _repo.AllInclude(includeProperties);
        }
    }
}
