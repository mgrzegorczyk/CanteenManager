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
        public string Role { get; protected set; }

        protected User() { }

        public User(Guid userId, string email, string password, string salt, string firstName, string lastName, string role)
        {
            Id = userId;
            SetEmail(email);
            SetPassword(password, salt);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            const int minPasswordLength = 6;

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password can not be empty!", nameof(password));
            }

            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentException("Salt can not be empty!", nameof(salt));
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
                throw new ArgumentException("Email can not be empty!", nameof(email));
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
                throw new ArgumentException("First name can not be empty!", nameof(firstName));
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
                throw new ArgumentException("Last name can not be empty!", nameof(lastName));
            }

            if (LastName == lastName)
            {
                return;
            }

            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role can't be empty!", nameof(role));
            }
            if (Role == role)
            {
                return;
            }
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}