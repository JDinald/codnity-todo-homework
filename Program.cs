using codnity_todo_homework.Data;
using Microsoft.EntityFrameworkCore;

namespace codnity_todo_homework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TodoDbContext>(opt =>opt.UseSqlite("DataSource = TodoDatabase.db"));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
