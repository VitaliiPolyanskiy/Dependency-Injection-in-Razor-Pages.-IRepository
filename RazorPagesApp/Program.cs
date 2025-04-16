using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

var builder = WebApplication.CreateBuilder(args);
// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IRepository, StudentRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();
