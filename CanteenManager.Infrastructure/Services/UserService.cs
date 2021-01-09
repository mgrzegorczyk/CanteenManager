using System;
using System.Threading.Tasks;
using AutoMapper;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;
using CanteenManager.Infrastructure.DTO;
using CanteenManager.Infrastructure.Extensions;

namespace CanteenManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IEncrypter encrypter;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IEncrypter encrypter
        )
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.encrypter = encrypter;
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await userRepository.GetAsync(email);

            if (user == null)
            {
                throw new Exception($"User with e-mail '{email}' does not exist!");
            }

            return mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string password, string firstName, string lastName)
        {
            var user = await userRepository.GetAsync(email);

            if (user != null)
            {
                throw new Exception($"User with e-mail '{email}' already exist!");
            }

            var salt = encrypter.GetSalt(password);
            var hash = encrypter.GetHash(password, salt);

            user = new User(email, hash, salt, firstName, lastName);

            await userRepository.AddAsync(user);
        }
        
        public async Task LoginAsync(string email, string password)
        {
            var user = await userRepository.GetAsync(email);

            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var salt = encrypter.GetSalt(password);
            var hash = encrypter.GetHash(password, salt);

            if (user.Password == hash)
            {
                return;
            }

            throw new Exception("Invalid credentials");
        }

    }
}