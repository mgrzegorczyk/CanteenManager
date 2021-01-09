using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}