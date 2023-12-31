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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Vezeta.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IUnitOfWork, UniteOfWork>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddAuth(configuration);

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


    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        return services;
    }
} 