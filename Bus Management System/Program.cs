using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shuttle.Areas.Identity.Data;
using shuttle.Data;
using shuttle.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("shuttleContextConnection") ?? throw new InvalidOperationException("Connection string 'shuttleContextConnection' not found.");

builder.Services.AddDbContext<shuttleContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<shuttleUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<shuttleContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext>(options =>
options.UseSqlServer(connectionString));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("shuttleContextConnection")));

builder.Services.AddDbContext<AddBusDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("shuttleContextConnection")));



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();
app.Run();
