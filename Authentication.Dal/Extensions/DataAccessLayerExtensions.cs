using Authentication.Dal.Configuration;
using Authentication.Dal.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Dal.Extensions;
public static class DataAccessLayerExtensions
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUserRespository, UserRespository>();

        return serviceCollection;
    }

    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection serviceCollection,
                                                             IConfiguration configuration)
    {
        serviceCollection.Configure<MongoDbConfiguration>(configuration.GetSection(nameof(MongoDbConfiguration)));

        return serviceCollection;
    }
}
