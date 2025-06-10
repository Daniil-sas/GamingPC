using BookingService.Application;
using BookingService.Extensions;
using BookingService.Infrastructure;
using BookingService.Persistence;
using BookingService.Persistence.Mappings;
using BookingService.Persistence.Settings;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
var configuration = builder.Configuration;

services.AddScoped<GlobalExceptionHandler>();

services.Configure<DatabaseSetting>(configuration.GetSection("Database"));
services.AddAutoMapper(typeof(DatabaseMappings));

services.AddHttpContextAccessor();

services
    .AddApplciation()
    .AddInfrastructure()
    .AddPersistence();

services.AddProblemDetails();
services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbServices = scope.ServiceProvider;
    var context = dbServices.GetRequiredService<BookingServiceDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddMappedEndpoints();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.Run();
