using System;
using AutoMapper;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public UserDto GetUser(string email)
        {
            var user = userRepository.Get(email);

            if (user == null)
            {
                throw new Exception($"User with e-mail '{email}' does not exist!");
            }

            return mapper.Map<User,UserDto>(user);
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