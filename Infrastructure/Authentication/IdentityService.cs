using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public class IdentityService : IIdentityService
{
    private readonly JwtOptions _options;

    public IdentityService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public async Task<string> GenerateToken(User user)
    {
        var claims = new Claim[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Mail.Value)
            };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)), 
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer, 
            _options.Audience, 
            claims, null, 
            DateTime.UtcNow.AddDays(1), 
            credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
