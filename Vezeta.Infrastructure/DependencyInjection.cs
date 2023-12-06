using Vezeta.Application.Common.Interfaces.Authentication;
using Vezeta.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Vezeta.Application.Common.Interfaces.Services;
using Vezeta.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Vezeta.Infrastructure.Repositories.Persistance;
using Microsoft.AspNetCore.Identity;
using Vezeta.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UniteOfWork>();

        services.AddDbContext<VezetaDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=Vezeta;User Id = SA; Password = Sabek@184; TrustServerCertificate=True;");
        });
        
        services.AddIdentity<User, IdentityRole<int>>()
        .AddEntityFrameworkStores<VezetaDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<UserManager<Admin>>();
        services.AddScoped<UserManager<Patient>>();
        services.AddScoped<UserManager<Doctor>>();

        services.AddScoped<IUserStore<Admin>, UserStore<Admin, IdentityRole<int>, VezetaDbContext, int>>();
        services.AddScoped<IUserStore<Patient>, UserStore<Patient, IdentityRole<int>, VezetaDbContext, int>>();
        services.AddScoped<IUserStore<Doctor>, UserStore<Doctor, IdentityRole<int>, VezetaDbContext, int>>();

        services.AddScoped<IPasswordHasher<Admin>, PasswordHasher<Admin>>();
        services.AddScoped<IPasswordHasher<Patient>, PasswordHasher<Patient>>();
        services.AddScoped<IPasswordHasher<Doctor>, PasswordHasher<Doctor>>();

        return services;
    }


} 