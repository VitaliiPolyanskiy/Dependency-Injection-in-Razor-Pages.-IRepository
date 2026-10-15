using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Отримуємо рядок підключення з файлу конфігурації
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Додаємо контекст StudentContext як сервіс у застосунок
builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer(connection));

// Додаємо сервіси Razor Pages
builder.Services.AddRazorPages();

// Реєструємо репозиторій для впровадження залежностей
builder.Services.AddScoped<IRepository, StudentRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();