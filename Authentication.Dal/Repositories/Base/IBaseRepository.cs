using Authentication.Dal.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Authentication.Dal.Repositories.Base;
public interface IBaseRepository
{
}

public abstract class BaseRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;
    protected BaseRepository(IOptions<MongoDbConfiguration> mongoDbConfiguration)
    {
        _collection = new MongoClient(mongoDbConfiguration.Value.ConnectionString)
          .GetDatabase(mongoDbConfiguration.Value.DatabaseName).GetCollection<T>(typeof(T).Name);
    }
}
