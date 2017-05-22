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
            if (user == null) throw new ArgumentNullException(nameof(user));

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
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return _repo.FindAll(predicate);
        }
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (includeProperties == null) throw new ArgumentNullException(nameof(includeProperties));
            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params string[] includeProperties)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (includeProperties == null) throw new ArgumentNullException(nameof(includeProperties));
            return _repo.FindAll(predicate, includeProperties);
        }
        public IEnumerable<User> AllInclude(params Expression<Func<User, object>>[] incluedProperties)
        {
            if (incluedProperties == null) throw new ArgumentNullException(nameof(incluedProperties));
            if (incluedProperties.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(incluedProperties));
            return _repo.AllInclude(incluedProperties);
        }
        public IEnumerable<User> AllInclude(params string[] incluedProperties)
        {
            if (incluedProperties == null) throw new ArgumentNullException(nameof(incluedProperties));
            if (incluedProperties.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(incluedProperties));
            return _repo.AllInclude(incluedProperties);
        }
        public void Update(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _repo.Update(user);
        }

        public void Delete(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
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
