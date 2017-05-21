using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Services
{
    public interface ITraningService
    {
        void Add(Training training);
        IEnumerable<Training> GetAll();
        Training Find(int id);
        IEnumerable<Training> FindAll(Expression<Func<Training, bool>> predicate);
        IEnumerable<Training> AllInclude(params Expression<Func<Training, object>>[] predicate);
        void Update(Training training);
        void Delete(Training training);
        IEnumerable<Training> AllInclude(params string[] includeProperties);

    }
}
