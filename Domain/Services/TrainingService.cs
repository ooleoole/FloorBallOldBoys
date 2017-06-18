using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Utilities;

namespace Domain.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepo<Training> _repo;

        public TrainingService(IRepo<Training> repo)
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

        //public Training Find(int id)
        //{
        //    return _repo.Find(id);
        //}

        public Training Find(int id, params string[] includeProperties)
        {
            return _repo.Find(t => t.Id == id, includeProperties);

        }

        public IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate)
        {
            NullCheck.ThrowArgumentNullEx(predicate);
            return _repo.FindAll(predicate);
        }

        public IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate,
            params Expression<Func<Training, object>>[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(predicate, includeProperties);

            return _repo.FindAll(predicate, includeProperties);
        }

        public IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate,
            params string[] includeProperties)
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

        public IEnumerable<Training> GetTodaysTrainings()
        {
            return _repo.AllInclude("EnrolledUsers.User")
                .Where(t => t.Date.Date == DateTime.Today);
        }
    }
}