using System;
using System.Threading.Tasks;
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

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await userRepository.GetAsync(email);

            if (user == null)
            {
                throw new Exception($"User with e-mail '{email}' does not exist!");
            }

            return mapper.Map<User,UserDto>(user);
        }

        public async Task RegisterAsync(string email, string password, string firstName, string lastName)
        {
            var user = await userRepository.GetAsync(email);

            if (user != null)
            {
                throw new Exception($"User with e-mail '{email}' already exist!");
            }

            var salt = Guid
                .NewGuid()
                .ToString();

            user = new User(email, password, salt, firstName, lastName);

            await userRepository.AddAsync(user);
        }

    }
}