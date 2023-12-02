using Vezeta.Application.Common.Interfaces.Authentication;
using Vezeta.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Vezeta.Application.Common.Interfaces.Services;
using Vezeta.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace Vezeta.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }


} 