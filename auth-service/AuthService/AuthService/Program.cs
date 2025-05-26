using AuthService.Application;
using AuthService.Extensions;
using AuthService.Infrastructure;
using AuthService.Infrastructure.Settings;
using AuthService.Middleware;
using AuthService.Persistence;
using AuthService.Persistence.Mappings;
using AuthService.Persistence.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<DatabaseSettings>(configuration.GetSection("Database"));
services.Configure<RedisSetting>(configuration.GetSection("Redis"));
services.AddOptions<RedisSetting>()
    .Bind(configuration.GetSection("Redis"));

services.AddApiAuthentication(configuration);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<GlobalExceptionHandler>();

services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

services
    .AddPersistence()
    .AddApplication()
    .AddInfrastructure();

services.AddProblemDetails();
services.AddExceptionHandler<GlobalExceptionHandler>();

services.AddAutoMapper(typeof(DataBaseMappings));

services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbServices = scope.ServiceProvider;
    var context = dbServices.GetRequiredService<AuthServiceDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseRequestLogContext();

app.UseAuthentication();

app.UseAuthorization();

app.AddMappedEndpoints();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.MapGet("get", [Authorize] () =>
{
    return Results.Ok("ok");
});

app.Run();
