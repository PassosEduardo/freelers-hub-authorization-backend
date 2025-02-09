using Authentication.API.Requests;
using Authentication.Domain.Models;

namespace Authentication.API.Services.Interfaces;

public interface IAuthService
{
    Task<bool> SignUp(SignUpRequest request);
    Task<TokenResponseModel> LogIn(LogInRequest request);
}
