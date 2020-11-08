using System;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDto GetUser(string email)
        {
            var user = userRepository.Get(email);

            if (user == null)
            {
                throw new Exception($"User with e-mail '{email}' does not exist!");
            }

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedAt = user.CreatedAt,
            };
        }

        public void Register(string email, string password, string firstName, string lastName)
        {
            var user = userRepository.Get(email);

            if (user != null)
            {
                throw new Exception($"User with e-mail '{email}' already exist!");
            }

            var salt = Guid
                .NewGuid()
                .ToString();

            user = new User(email, password, salt, firstName, lastName);

            userRepository.Add(user);
        }

    }
}