using Authentication.API.Services;
using Authentication.API.Services.Interfaces;

namespace Authentication.API.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IAuthService, AuthService>();

        return services;
    }
}
