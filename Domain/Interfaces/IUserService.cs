using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(int id);
        IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate);

        IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate,
            params string[] includeProperties);

        IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate,
            params Expression<Func<User, object>>[] includeProperties);

        IEnumerable<User> AllInclude(params string[] incluedProperties);
        IEnumerable<User> AllInclude(params Expression<Func<User, object>>[] incluedProperties);
        void Update(User user);
        void Delete(User user);
    }
}