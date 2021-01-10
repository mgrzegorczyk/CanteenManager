using System.Threading.Tasks;
using CanteenManager.Infrastructure.Commands;
using CanteenManager.Infrastructure.Commands.User;
using CanteenManager.Infrastructure.Extensions;
using CanteenManager.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace CanteenManager.Infrastructure.Handlers.Users
{
    public class LoginHandler : IAppCommandHandler<Login>
    {
        private readonly IUserService userService;
        private readonly IJwtHandler jwtHandler;
        private readonly IMemoryCache memoryCache;

        public LoginHandler(
            IUserService userService,
            IJwtHandler jwtHandler,
            IMemoryCache memoryCache
        )
        {
            this.userService = userService;
            this.jwtHandler = jwtHandler;
            this.memoryCache = memoryCache;
        }

        public async Task HandleAsync(Login command)
        {
            await userService.LoginAsync(command.Email, command.Password);
            
            var user = await userService.GetUserAsync(command.Email);

            var jwt = jwtHandler.CreateToken(command.Email, user.Role);

            memoryCache.SetJwt(command.TokenId, jwt);
        }
    }
}