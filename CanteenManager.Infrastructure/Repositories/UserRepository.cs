using System;
using System.Collections.Generic;
using System.Linq;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;

namespace CanteenManager.Infrastructure.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("test@mail.com", "testpwd", "salt", "John", "Doe")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            return _users.SingleOrDefault(user => user.Id == id);
        }

        public User Get(string email)
        {
            return _users.SingleOrDefault(user => user.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}