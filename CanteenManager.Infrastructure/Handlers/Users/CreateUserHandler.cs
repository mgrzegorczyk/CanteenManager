using System;
using System.Threading.Tasks;
using CanteenManager.Infrastructure.Commands;
using CanteenManager.Infrastructure.Commands.User;
using CanteenManager.Infrastructure.Services;

namespace CanteenManager.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : IAppCommandHandler<CreateUser>
    {
        private readonly IUserService userService;
        public CreateUserHandler(IUserService userService)
        {
            this.userService = userService;

        }
        public async Task HandleAsync(CreateUser createUserCommand)
        {
            var userId = Guid.NewGuid();
            var role = "user";

            await userService.RegisterAsync(userId, createUserCommand.Email, createUserCommand.Password, createUserCommand.FirstName, createUserCommand.LastName, role);
        }
    }
}