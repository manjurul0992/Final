using Final.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FinalContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("appCon")));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Players}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "abc",
    pattern: "abc",
    defaults: new { controller = "Players", action = "Index" }
    );

app.Run();
