using BookingService.Persistence;
using BookingService.Persistence.Mappings;
using BookingService.Persistence.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<DatabaseSetting>(configuration.GetSection("Database"));
services.AddAutoMapper(typeof(DatabaseMappings));

services
    .AddPersistence();

var app = builder.Build();

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

app.MapGet("get", () =>
{
    return Results.Ok("ok");
});

app.Run();
