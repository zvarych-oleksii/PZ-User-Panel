using BusinessLogic.BL;
using DAL.Context;
using DAL.Data.Models;
using DTO_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main()
    {
        // Setup Dependency Injection
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("myconn");

        var serviceProvider = new ServiceCollection()
            .AddDbContext<StoreDBContext>(options =>
                options.UseSqlServer(connectionString)
            )
            .AddScoped<ProductRepository>()
            .AddScoped<CartRepository>()
            .AddScoped<UserRepository>()
            .AddScoped<CategoryRepository>()
            .AddScoped<UserBL>()  // Make sure UserBL is registered in your DI container
            .BuildServiceProvider();

        var categoryRepo = serviceProvider.GetRequiredService<CategoryRepository>();
        var cartRepo = serviceProvider.GetRequiredService<CartRepository>();
        var productRepo = serviceProvider.GetRequiredService<ProductRepository>();
        var userRepo = serviceProvider.GetRequiredService<UserRepository>();
        var userBL = serviceProvider.GetRequiredService<UserBL>(); // Fix the declaration here

        User user = new User
        {
            UserName = "Josht",
            Password = "password",
            Salt = ""
        };

        Product product = new Product
        {
            ProductName = "TestProduct",
            ProductDescription = "TestDescription",
            Quantity = 20,
            CategoryId = 1,
            Price = 200,
        };


        Cart cart = new Cart
        {
            UserId = 10,
            ProductId = 5,
            Quantity = 5,
        };
        if (serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
