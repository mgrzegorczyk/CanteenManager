using System;

namespace CanteenManager.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}