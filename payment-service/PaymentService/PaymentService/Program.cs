using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentService.Data;
using PaymentService.Models.Settings;
using PaymentService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("Database"));

builder.Services.AddDbContext<AppDbContext>((dbService, options) =>
{
    var setting = dbService.GetRequiredService<IOptions<DatabaseSetting>>().Value;

    options.UseNpgsql(setting.ConnectionString);
});

builder.Services.AddScoped<PaymentsService>();
builder.Services.AddSingleton<QrCodeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbServices = scope.ServiceProvider;
    var context = dbServices.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();