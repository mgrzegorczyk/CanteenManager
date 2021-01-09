using System;
using System.Security.Cryptography;
using CanteenManager.Infrastructure.Extensions;

namespace CanteenManager.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int deriveBytesIterationsCount = 1000;
        private static readonly int saltSize = 40;

        public string GetHash(string value, string salt)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("Can't generate hash from empty value", nameof(value));
            }

            if (salt.IsEmpty())
            {
                throw new ArgumentException("Can't use empty salt for hashing value", nameof(salt));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), deriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(saltSize));
        }

        public string GetSalt(string value)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("Can't generate salt from empty value", nameof(value));
            }

            var random = new Random();
            var saltBytes = new byte[saltSize];
            var rng = RandomNumberGenerator.Create();

            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
        
        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}