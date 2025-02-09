using Authentication.API.Requests;
using Authentication.API.Services.Interfaces;
using Authentication.Dal.Repositories;
using Authentication.Domain.Handlers;
using Authentication.Domain.Models;

namespace Authentication.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRespository _usersRepository;

    public AuthService(IUserRespository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<bool> SignUp(SignUpRequest request)
    {
        var userExists = await _usersRepository.IsEmailInUse(request.Email);

        if (userExists)
            return false;

        var credentials = SaltHandler.CreateUserCredentials(request.Password);

        return await _usersRepository.CreateUser(request.Email,
                                                 credentials.EncryptedPassword,
                                                 credentials.EncryptedSalt);
    }

    public async Task<TokenResponseModel> LogIn(LogInRequest request)
    {
        var credentials = await _usersRepository.GetUserByLogInCredentials(request.Email, request.Password);

        if (credentials is null)
            return null; //usuario nao encontrado

        return TokenHandler.GenerateToken();
    }
}
