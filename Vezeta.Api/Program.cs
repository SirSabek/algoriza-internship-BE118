using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using Vezeta.Api.Common.Errors;
using Vezeta.Api.Configurations;
using Vezeta.Application;
using Vezeta.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
        
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, VezetaProblemDetailsFactory>();
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5001");
        });
    });

    builder.Services.AddAutoMapper(typeof(MapperInitializer));

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAdminDoctorPatient", policy =>
            policy.RequireRole("Admin", "Doctor", "Patient"));
    });
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseRouting();  
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseCors("CorsPolicy");
    app.MapControllers();
    app.Run();
}