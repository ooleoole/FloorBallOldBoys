using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
   

    public class UserService : IUserService
    {
        private readonly IRepo<User> _repo;

        public UserService(IRepo<User> repo)
        {
            _repo = repo;
        }

        public void Add(User user)
        {
            _repo.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll();
        }

        public User Find(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<User> FindAll(Expression<Func<User,bool>> predicate)
        {
            return _repo.FindAll(predicate);
        }

        public IEnumerable<User> AllInclude(params Expression<Func<User, object>> []predicate)
        {
            return _repo.AllInclude(predicate);
        }

        public void Update(User user)
        {
            _repo.Update(user);
        }
    }
}
