using Authentication.Dal.Entities;

namespace Authentication.Dal.Repositories;
public interface IUserRespository
{
    Task<UserEntity> GetUserByLogInCredentials(string email, string password);
    Task<bool> IsEmailInUse(string email);
    Task<bool> CreateUser(string email, string password, string salt);
}
