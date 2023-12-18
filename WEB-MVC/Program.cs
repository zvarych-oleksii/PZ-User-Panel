using BusinessLogic.BL;
using BusinessLogic.IBL;
using DAL.Context;
using DAL.Data.IModels;
using DAL.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WEB_MVC.App;
using WEB_MVC.Areas.Identity.Data;
using WEB_MVC.Data;
using WEB_MVC.Static;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WEB_MVCContextConnection") ?? throw new InvalidOperationException("Connection string 'WEB_MVCContextConnection' not found.");

builder.Services.AddDbContext<WEB_MVCContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<StoreDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<WEB_MVCUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WEB_MVCContext>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICartBL, CartBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<IProductBL, ProductBL>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapControllerRoute(
    name: "cart",
    pattern: "{controller=Cart}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// ...

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = Enum.GetNames(typeof(Roles));

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}



app.Run();
