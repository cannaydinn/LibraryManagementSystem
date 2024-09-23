

using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});


var app = builder.Build();
app.UseStaticFiles(); // wwwroot
app.UseAuthentication();


app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Auth}/{action=Login}");

app.Run();
    