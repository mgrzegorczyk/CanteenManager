using System;

namespace CanteenManager.Core.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User() { }

        public User(string email, string password, string salt, string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Salt = salt;
            FirstName = firstName;
            LastName = lastName;
            CreatedAt = DateTime.UtcNow;
        }
    }
}