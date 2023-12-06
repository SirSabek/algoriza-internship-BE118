using Microsoft.Extensions.DependencyInjection;
using Vezeta.Application.Services.Authentication;
using Vezeta.Application.Services.Authentication.Auth;

namespace Vezeta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService,AuthenticationService>();
        services.AddScoped(typeof(IAuthManager<>), typeof(AuthManager<>) );

        return services;
    }


} 