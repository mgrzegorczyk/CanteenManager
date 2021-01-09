using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CanteenManager.Infrastructure.DTO;
using CanteenManager.Infrastructure.Extensions;
using CanteenManager.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;

namespace CanteenManager.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings jwtSettings;

        public JwtHandler(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }
        
        public JwtDto CreateToken(string email, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(
                    JwtRegisteredClaimNames.Iat,
                    now.ToTimestamp().ToString(),
                    ClaimValueTypes.Integer64
                )
            };

            var singingCredintials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256
            );

            var expires = now.AddMinutes(jwtSettings.ExpiryMinutes);

            var jwt = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: singingCredintials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}