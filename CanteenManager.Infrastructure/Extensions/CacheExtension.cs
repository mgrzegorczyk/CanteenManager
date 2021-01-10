using System;
using CanteenManager.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace CanteenManager.Infrastructure.Extensions
{
    public static class CacheExtension
    {
        public static void SetJwt(this IMemoryCache memoryCache, Guid tokenId, JwtDto jwt)
        {
            memoryCache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));
        }

        public static JwtDto GetJwt(this IMemoryCache memoryCache, Guid tokenId)
        {
            return memoryCache.Get<JwtDto>(GetJwtKey(tokenId));
        }

        private static string GetJwtKey(Guid tokenId)
        {
            return $"jwt-{tokenId}";
        }
    }
}