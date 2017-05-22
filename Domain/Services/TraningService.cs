using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Utilities;

namespace Domain.Services
{
    public class TraningService : ITraningService
    {
        private readonly IRepo<Training> _repo;

        public TraningService(IRepo<Training> repo)
        {
            _repo = repo;
        }

        public void Add(Training training)
        {
            NullCheck.ThrowArgumentNullEx(training);
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
            NullCheck.ThrowArgumentNullEx(predicate);
            return _repo.FindAll(predicate);
        }
        public IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate, params Expression<Func<Training, object>>[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(predicate, includeProperties);

            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate, params string[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(predicate, includeProperties);
            return _repo.FindAll(predicate, includeProperties);
        }


        public void Update(Training training)
        {
            NullCheck.ThrowArgumentNullEx(training);
            _repo.Update(training);
        }

        public void Delete(Training training)
        {
            NullCheck.ThrowArgumentNullEx(training);
            _repo.Delete(training);
        }

        public IEnumerable<Training> AllInclude(params string[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(includeProperties);

            return _repo.AllInclude(includeProperties);
        }
        public IEnumerable<Training> AllInclude(params Expression<Func<Training, object>>[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(includeProperties);
            return _repo.AllInclude(includeProperties);
        }
    }
}
