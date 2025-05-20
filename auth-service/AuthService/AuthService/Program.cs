using AuthService.Application;
using AuthService.Application.Settings;
using AuthService.Extensions;
using AuthService.Infrastructure;
using AuthService.Middleware;
using AuthService.Persistence;
using AuthService.Persistence.Mappings;
using AuthService.Persistence.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<DatabaseSettings>(configuration.GetSection("Database"));

services.AddApiAuthentication(configuration);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<GlobalExceptionHandler>();

services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

services
    .AddPersistence(configuration)
    .AddApplication()
    .AddInfrastructure();

services.AddProblemDetails();
services.AddExceptionHandler<GlobalExceptionHandler>();

services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseRequestLogContext();

app.UseAuthentication();

// app.UseAuthorization();

app.AddMappedEndpoints();

app.MapGet("get", () =>
{
    return Results.Ok("ok");
});

app.Run();
