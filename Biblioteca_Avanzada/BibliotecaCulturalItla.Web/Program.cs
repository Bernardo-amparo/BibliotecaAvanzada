using BibliotecaCulturalItla.Data;
using BibliotecaCulturalItla.Domain.Repositories;
using BibliotecaCulturalItla.Services;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar DBConnection
builder.Services.AddSingleton(new DBConnection(conn));

// Registrar repositorios y servicios
builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<BookService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();