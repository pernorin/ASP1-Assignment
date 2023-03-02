using ASP1_Assignment.Contexts;
using ASP1_Assignment.Models.Identity;
using ASP1_Assignment.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // behöver denna ligga under dep.inj.?

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
//builder.Services.AddScoped<ProductService>(); // Ej gjord än
//builder.Services.AddScoped<ContactService>(); // Ej gjord än

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<IdentityContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
});

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
