using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Infrastructure.OptionsSetup;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Auth;

internal sealed class JwtTokenProvider : IJwtTokenProvider
{
    private readonly JwtSettings _settings;

    public JwtTokenProvider(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }

    public LoginResponse CreateToken(UserModel user, string role)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = CreateTokenDescriptor(user, role, expiration);

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new LoginResponse(tokenHandler.WriteToken(token), expiration);
    }

    private SecurityTokenDescriptor CreateTokenDescriptor(UserModel user, string role, DateTime expiration)
    {
        return new SecurityTokenDescriptor
        {
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            Expires = expiration,
            SigningCredentials = CreateSigningCredentials(),
            Subject = new ClaimsIdentity(CreataClaims(user, role))

        };
    }

    private Claim[] CreataClaims(UserModel user, string role)
    {
        List<Claim> claims = new()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
            new Claim(JwtRegisteredClaimNames.Name, user.Name!),
            new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
            new Claim(JwtRegisteredClaimNames.Aud, _settings.Audience),
            new Claim(ClaimTypes.Role, role)
        };

        return claims.ToArray();
    }


    private SigningCredentials CreateSigningCredentials() =>
        new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey)),
            SecurityAlgorithms.HmacSha256);
}
