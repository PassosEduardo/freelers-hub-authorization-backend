using Authentication.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Authentication.Domain.Handlers;

public static class TokenHandler
{
    private const string SUPER_SECRET_HASH = "AFKSJDLFAJSDLFKJSDLKFJSAKLFJSADLKJFLA";
    public static TokenResponseModel GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SUPER_SECRET_HASH);
        var tokenDescriptior = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                        SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptior);

        return new TokenResponseModel(tokenHandler.WriteToken(token), token.ValidTo);
    }
}
public sealed record AuthenticationCredentials
{
    public string EncryptedPassword { get; set; }
    public string EncryptedSalt { get; set; }

    public AuthenticationCredentials(string encryptedPassword, string encryptedSalt)
    {
        EncryptedPassword = encryptedPassword;
        EncryptedSalt = encryptedSalt;
    }
}
