using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITrainingService
    {
        void Add(Training training);
        IEnumerable<Training> GetAll();
        //Training Find(int id);
        IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate);

        IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate,
            params Expression<Func<Training, object>>[] includeProperties);

        IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate,
            params string[] includeProperties);

        void Update(Training training);
        void Delete(Training training);
        IEnumerable<Training> AllInclude(params string[] includeProperties);
        IEnumerable<Training> AllInclude(params Expression<Func<Training, object>>[] predicate);
        IEnumerable<Training> GetTodaysTrainings();
        Training Find(int id, params string[] includeProperties);
    }
}