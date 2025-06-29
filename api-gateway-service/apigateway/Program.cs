using ApiGateway;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: false);
services.AddOcelot(builder.Configuration);

var jwtConfig = builder.Configuration.GetSection("JwtSetting");

services.AddScoped<GlobalExceptionHandler>();
services.AddProblemDetails();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Jwt", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Secret"]))
        };
    });

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Example", Version = "v1" });
});

services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseOcelot().Wait();
app.MapControllers();

app.Run();
