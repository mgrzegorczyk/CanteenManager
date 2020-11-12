using CanteenManager.Infrastructure.Commands;

namespace CanteenManager.Infrastructure.Commands.User
{
    public class CreateUser : IAppCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}