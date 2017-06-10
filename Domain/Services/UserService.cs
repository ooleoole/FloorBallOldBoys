using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Utilities;

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
            NullCheck.ThrowArgumentNullEx(user);
            var address = GetExistingAddress(user);
            if (address != null)
                SetUserAddressToExistingAddress(user, address);


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
            NullCheck.ThrowArgumentNullEx(predicate);
            return _repo.FindAll(predicate);
        }
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(predicate, includeProperties);
            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params string[] includeProperties)
        {
            NullCheck.ThrowArgumentNullEx(predicate, includeProperties);
            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<User> AllInclude(params Expression<Func<User, object>>[] incluedProperties)
        {
            NullCheck.ThrowArgumentNullEx(incluedProperties);
                
            return _repo.AllInclude(incluedProperties);
        }
        public IEnumerable<User> AllInclude(params string[] incluedProperties)
        {
            NullCheck.ThrowArgumentNullEx(incluedProperties);
            return _repo.AllInclude(incluedProperties);
        }
        public void Update(User user)
        {
            NullCheck.ThrowArgumentNullEx(user);
            _repo.Update(user);
        }

        public void Delete(User user)
        {
            NullCheck.ThrowArgumentNullEx(user);
            _repo.Delete(user);
        }

        private static void SetUserAddressToExistingAddress(User user, Address address)
        {
            user.AddressId = address.Id;
            user.Address = null;
           
        }

        private Address GetExistingAddress(User user)
        {
            return _addressRepo.FindAll(a => a.City == user.Address.City &&
                                             a.Street == user.Address.Street &&
                                             a.ZipCode == user.Address.ZipCode).FirstOrDefault();
        }
    }
}
