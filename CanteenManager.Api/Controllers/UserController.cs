using System.Threading.Tasks;
using CanteenManager.Infrastructure.Commands.User;
using CanteenManager.Infrastructure.DTO;
using CanteenManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;

        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await userService.GetUserAsync(email);

            if(user == null) 
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser user)
        {
            await userService.RegisterAsync(user.Email, user.Password, user.FirstName, user.LastName);

            return Created($"user/{user.Email}", user);
        }
    }
}