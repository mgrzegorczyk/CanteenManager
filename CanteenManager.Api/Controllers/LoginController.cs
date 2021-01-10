using System;
using System.Threading.Tasks;
using CanteenManager.Infrastructure.Commands;
using CanteenManager.Infrastructure.Commands.User;
using CanteenManager.Infrastructure.Extensions;
using CanteenManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CanteenManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ApiControllerBase
    {
        private readonly IAppCommandDispatcher appCommandDispatcher;
        private readonly IMemoryCache memoryCache;

        public LoginController(
            IAppCommandDispatcher appCommandDispatcher,
            IMemoryCache memoryCache
        ) : base(appCommandDispatcher)
        {
            this.appCommandDispatcher = appCommandDispatcher;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> Login([FromBody] Login command)
        {
            command.TokenId = Guid.NewGuid();

            await appCommandDispatcher.DispatchAsync(command);

            var jwt = memoryCache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}