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
        public DateTime UpdatedAt { get; protected set; }

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

        public void SetPassword(string password, string salt)
        {
            const int minPasswordLength = 6;

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty!");
            }

            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty!");
            }

            if (password.Length < minPasswordLength)
            {
                throw new Exception($"Password must contain at least {minPasswordLength} characters!");
            }

            if (Password == password)
            {
                return;
            }

            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty!");
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("First name can not be empty!");
            }

            if (FirstName == firstName)
            {
                return;
            }

            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Last name can not be empty!");
            }

            if (LastName == lastName)
            {
                return;
            }

            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}