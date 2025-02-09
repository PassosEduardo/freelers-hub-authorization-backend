using Authentication.Dal.Configuration;
using Authentication.Dal.Entities;
using Authentication.Dal.Repositories.Base;
using Authentication.Domain.Handlers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Authentication.Dal.Repositories;

public class UserRespository : BaseRepository<UserEntity>, IUserRespository
{
    public UserRespository(IOptions<MongoDbConfiguration> mongoDbConfiguration) : base(mongoDbConfiguration)
    {
    }

    public async Task<bool> CreateUser(string email, string password, string salt)
    {
        try
        {
            await _collection.InsertOneAsync(new UserEntity
            {
                Email = email,
                Password = password,
                Salt = salt
            });

        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<UserEntity> GetUserByLogInCredentials(string email, string password)
    {
        var query = await _collection.FindAsync(x => string.Equals(email, x.Email));

        var user = query.FirstOrDefault();

        if (user is null)
            return null;

        var encryptedPassword = SaltHandler.EncrypPassword(password, user.Salt);

        if (string.Equals(user.Password, encryptedPassword))
            return user;

        return null;
    }

    public async Task<bool> IsEmailInUse(string email)
    {
       return await _collection.CountDocumentsAsync(x =>  x.Email == email) > 0;
    }
}
