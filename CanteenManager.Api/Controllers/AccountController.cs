using CanteenManager.Infrastructure.Commands;
using CanteenManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler jwtHandler;

        public AccountController(
            IAppCommandDispatcher appCommandDispatcher,
            IJwtHandler jwtHandler
        ) : base(appCommandDispatcher)
        {
            this.jwtHandler = jwtHandler;
        }
    }
}