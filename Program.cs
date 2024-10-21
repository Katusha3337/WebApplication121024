using Microsoft.EntityFrameworkCore;
using WebApplication121024.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контекст базы данных
builder.Services.AddDbContext<ApplicationDbContext>(opts => {
    opts.UseSqlServer(
    builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Используем статические файлы
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
