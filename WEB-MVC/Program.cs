using BusinessLogic.BL;
using BusinessLogic.IBL;
using DAL.Context;
using DAL.Data.IModels;
using DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEB_MVC.App;
using WEB_MVC.Areas.Identity.Data;
using WEB_MVC.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WEB_MVCContextConnection") ?? throw new InvalidOperationException("Connection string 'WEB_MVCContextConnection' not found.");

builder.Services.AddDbContext<WEB_MVCContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<StoreDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<WEB_MVCUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WEB_MVCContext>();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICartBL, CartBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<IProductBL, ProductBL>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllerRoute(
    name: "cart",
    pattern: "{controller=Cart}/{action=Index}/{id?}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
