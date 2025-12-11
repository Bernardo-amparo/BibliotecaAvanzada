using BibliotecaCulturalItla.Data;
using BibliotecaCulturalItla.Domain.Repositories;
using BibliotecaCulturalItla.Services;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DBConnection>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var conn = config.GetConnectionString("DefaultConnection");

    if (string.IsNullOrEmpty(conn))
    {
        throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no fue encontrada en appsettings.json.");
    }

    return new DBConnection(conn);
});
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