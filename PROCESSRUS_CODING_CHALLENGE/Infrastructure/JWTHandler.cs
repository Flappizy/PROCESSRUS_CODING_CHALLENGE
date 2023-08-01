using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PROCESSRUS_CODING_CHALLENGE.Entities.Models;
using PROCESSRUS_CODING_CHALLENGE.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PROCESSRUS_CODING_CHALLENGE.Infrastructure;
public class JWTHandler : IJWTHandler
{
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;
    private readonly UserManager<User> _userManager;

    public JWTHandler(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _jwtSettings = _configuration.GetSection("JwtSettings");
        _userManager = userManager;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return token;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private static List<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.PrimarySid, user.Id),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.AccountType.ToString())
        };

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _jwtSettings["validIssuer"],
            audience: _jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
            signingCredentials: signingCredentials);

        return tokenOptions;
    }
}
