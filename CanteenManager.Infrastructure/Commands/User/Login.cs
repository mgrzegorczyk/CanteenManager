using System;

namespace CanteenManager.Infrastructure.Commands.User
{
    public class Login : IAppCommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}