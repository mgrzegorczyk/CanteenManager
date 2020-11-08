using CanteenManager.Infrastructure.DTO;
using CanteenManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
            
        }

        [HttpGet("{email}")]
        public UserDto Get(string email)
        {
            return userService.GetUser(email);
        }
    }
}