using AuthService.Application.DTOs.JwtToken;
using AuthService.Application.Interfaces.Auth;
using AuthService.Domain.Models;
using AuthService.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthService.Infrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSetting _jwtSetting;
        public JwtProvider(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
        }

        public AccessToken GenerateToken(User user)
        {
            Claim[] claims = [
                new("userId", user.Id.ToString()),
                new("lifeTime", _jwtSetting.ExpiryMinutes.ToString())
                ];

            var token = new JwtSecurityToken(
                audience: _jwtSetting.Audience,
                issuer: _jwtSetting.Issuer,
                claims: claims,
                signingCredentials: new SigningCredentials(_jwtSetting.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256),
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.ExpiryMinutes));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return new(tokenValue, _jwtSetting.ExpiryMinutes);
        }

        public RefreshToken GenerateRefreshToken()
        {
            return new(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), TimeSpan.FromDays(_jwtSetting.RefreshTokenExpiryDays));
        }
    }
}
