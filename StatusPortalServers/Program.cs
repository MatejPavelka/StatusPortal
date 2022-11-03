using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StatusPortalServers.Data;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{environment}.json", true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
var dbConnString = $"Filename={configuration.GetConnectionString("SqlLiteConnectionFileName")}";
void DbContextOptionsBuilder(DbContextOptionsBuilder builder)
{
    builder.UseSqlite(dbConnString, sql => sql.MigrationsAssembly(migrationsAssembly));
}

builder.Services.AddDbContext<ApplicationDbContext>(DbContextOptionsBuilder);


builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IDecorationService, DecorationService>();
builder.Services.AddTransient<IStatusService, StatusService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
    // new SignalR endpoint routing setup
    endpoints.MapFallbackToFile("index.html");
});



app.Run();
