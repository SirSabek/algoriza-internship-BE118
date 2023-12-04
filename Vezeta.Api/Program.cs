using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Vezeta.Api", Version = "v1" });
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5001");
        });
    });

    builder.Services.AddAutoMapper(typeof(MapperInitializer));

}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}