using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Services
{
    public interface IUserService
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(int id);
        IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate);
        IEnumerable<User> AllInclude(params Expression<Func<User, object>>[] predicate);
        void Update(User user);
        void Delete(User user);
    }
}
