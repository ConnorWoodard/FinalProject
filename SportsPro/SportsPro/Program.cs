using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SportsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsContext"))); 

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
