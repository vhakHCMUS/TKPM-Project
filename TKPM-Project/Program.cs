using TKPM_Project.Models;
using TKPM_Project.Repositories;
using Microsoft.EntityFrameworkCore;
using TKPM_Project.Data;
using TKPM_Project.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Tự động đăng ký tất cả các class triển khai IService
var serviceInterfaceType = typeof(IService);
var allServiceTypes = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => serviceInterfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

foreach (var serviceType in allServiceTypes)
{
    builder.Services.AddScoped(serviceInterfaceType, serviceType);
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the MockAccountRepository
builder.Services.AddScoped<IAccountRepository, MockAccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Login route
app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Account}/{action=Login}");

app.MapControllerRoute(
    name: "tool",
    pattern: "Tool/{toolName}",
    defaults: new { controller = "Tool", action = "Tool" });

app.Run();
