using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{


    public class UserService : IUserService
    {
        private readonly IRepo<User> _repo;
        private readonly IRepo<Address> _addressRepo;

        public UserService(IRepo<User> repo, IRepo<Address> addressRepo)
        {
            _repo = repo;
            _addressRepo = addressRepo;
        }

        public void Add(User user)
        {

            var address = _addressRepo.FindAll(a => a.City == user.Address.City &&
                                                    a.Street == user.Address.Street &&
                                                    a.ZipCode == user.Address.ZipCode).FirstOrDefault();

            if (address != null)
            {
                user.AddressId = address.Id;
                user.Address = null;
            }
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

        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate)
        {
            return _repo.FindAll(predicate);
        }
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params string[] includeProperties)
        {
            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<User> AllInclude(params Expression<Func<User, object>>[] incluedProperties)
        {
            return _repo.AllInclude(incluedProperties);
        }
        public IEnumerable<User> AllInclude(params string[] incluedProperties)
        {
            return _repo.AllInclude(incluedProperties);
        }
        public void Update(User user)
        {
            _repo.Update(user);
        }

        public void Delete(User user)
        {
            _repo.Delete(user);
        }
    }
}
