using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto GetUser(string email);
        void Register(string email, string password, string firstName, string lastName);
    }
}