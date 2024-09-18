using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Kimlik doğrulama (cookie tabanlı)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.LoginPath = "/Login/Index"; // Başarısız login girişimlerinde yönlendirme
});

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// Middleware sıralaması
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication ve Authorization middleware
app.UseAuthentication();  // Kimlik doğrulama
app.UseAuthorization();   // Yetkilendirme

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
