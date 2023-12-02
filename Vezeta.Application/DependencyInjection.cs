using Microsoft.Extensions.DependencyInjection;
using Vezeta.Application.Services.Authentication;

namespace Vezeta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService,AuthenticationService>();

        return services;
    }


} 