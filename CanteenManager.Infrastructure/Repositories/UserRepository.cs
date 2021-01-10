using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;

namespace CanteenManager.Infrastructure.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("test@mail.com", "testpwd", "salt", "John", "Doe", "user")
        };

        public async Task AddAsync(User user)
        {
            await Task.FromResult(_users.Add(user));
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.Email == email));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}