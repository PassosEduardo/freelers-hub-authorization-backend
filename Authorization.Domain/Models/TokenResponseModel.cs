namespace Authentication.Domain.Models;

public class TokenResponseModel
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }

    public TokenResponseModel(string token, DateTime expirationDateTime)
    {
        Token = token;
        Expires = expirationDateTime;
    }
}
