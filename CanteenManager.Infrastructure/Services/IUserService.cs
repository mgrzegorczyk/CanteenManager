using System.Threading.Tasks;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUserAsync(string email);
        Task RegisterAsync(string email, string password, string firstName, string lastName);
        Task LoginAsync(string email, string password);
    }
}