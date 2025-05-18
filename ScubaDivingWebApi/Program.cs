using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScubaDivingWebApi.Extensions;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Injections
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


// Controller ve Swagger servisleri
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

// Swagger aktif
app.UseSwagger();
app.UseSwaggerUI();
app.ApplyMigrations();

// Tarayıcıyı otomatik aç
var url = app.Configuration["LaunchSwaggerUrl"] ?? "https://localhost:7096/swagger";
try
{
    Process.Start(new ProcessStartInfo
    {
        FileName = url,
        UseShellExecute = true
    });
}
catch (Exception ex)
{
    Console.WriteLine($"Tarayıcı açılamadı: {ex.Message}");
}

// HTTPS, Authorization ve Controller map
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapIdentityApi<User>();
app.Run();
