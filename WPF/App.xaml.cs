using BusinessLogic.BL;
using BusinessLogic.IBL;
using DAL.Context;
using DAL.Data.IModels;
using DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Windows;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using WPF.ViewModels;
using WPF.Windows;

namespace WPF
{
    public partial class App : Application
    {
        public IUnityContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);
            RegisterUnity();
            LoginView lf = Container.Resolve<LoginView>();
            bool? result = lf.ShowDialog();

            if (result.HasValue && result.Value)
            {
                ProductList pl = Container.Resolve<ProductList>();
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = pl;
                pl.Show();
            }

        }


        private void RegisterUnity()
        {
            Container = new UnityContainer();
            var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

            var connectionString = configuration.GetConnectionString("myconn");
            // Register DbContext
            Container.RegisterType<StoreDBContext>(
               new HierarchicalLifetimeManager(),
               new InjectionConstructor(
                   new DbContextOptionsBuilder<StoreDBContext>()
                       .UseSqlServer("Server=(local);Database=StoreDb;Integrated Security=True;TrustServerCertificate=True;")
                       .Options
               )
           );


            // Register repositories
            Container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            Container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            Container.RegisterType<ICartRepository, CartRepository>(new HierarchicalLifetimeManager());
            Container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());

            // Register business logic services
            Container.RegisterType<IUserBL, UserBL>(new HierarchicalLifetimeManager());
            Container.RegisterType<IProductBL, ProductBL>(new HierarchicalLifetimeManager());
            Container.RegisterType<ICartBL, CartBL>(new HierarchicalLifetimeManager());

            // Register view models
            Container.RegisterType<ProductListViewModel>(new HierarchicalLifetimeManager());
            Container.RegisterType<LoginViewModel>(new HierarchicalLifetimeManager());
            // Add other registrations as needed
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            Container?.Dispose();
        }
        //    private void OnStartup(object sender, StartupEventArgs e)
        //    {
        //        var host = new HostBuilder()
        //            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //            .ConfigureContainer<ContainerBuilder>(builder =>
        //            {
        //                ConfigureServices(builder);
        //            })
        //            .Build();

        //        _container = host as IContainer;

        //        using (var scope = _container.BeginLifetimeScope())
        //        {
        //            var productvm = scope.Resolve<ProductListViewModel>();

        //            var productListWindow = new ProductList(productvm);
        //            productListWindow.Show();
        //        }
        //    }

        //    private void ConfigureServices(ContainerBuilder builder)
        //    {
        //        var configuration = new ConfigurationBuilder()
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //            .Build();

        //        // Тут ми використовуємо розширення для IServiceCollection
        //        var serviceCollection = new ServiceCollection();
        //        serviceCollection.AddDbContext<StoreDBContext>(options =>
        //        {
        //            var connectionString = configuration.GetConnectionString("myconn");
        //            options.UseSqlServer(connectionString);
        //        });

        //        builder.Populate(serviceCollection);

        //        builder.RegisterType<UserRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        //        builder.RegisterType<ProductRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        //        builder.RegisterType<CartRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        //        builder.RegisterType<CategoryRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();

        //        // Register your business logic services
        //        builder.RegisterType<UserBL>().AsImplementedInterfaces().InstancePerLifetimeScope();
        //        builder.RegisterType<ProductBL>().As<IProductBL>().InstancePerLifetimeScope();
        //        builder.RegisterType<CartBL>().AsImplementedInterfaces().InstancePerLifetimeScope();

        //        // Register your view models
        //        builder.RegisterType<ProductListViewModel>().InstancePerLifetimeScope();
        //        // Add other services as needed
        //    }

        //    private void OnExit(object sender, ExitEventArgs e)
        //    {
        //        _container?.Dispose();
        //    }
        //}
    }
}

//using System.Windows;
//using WPF.Windows;

//namespace WPF
//{
//    public partial class App : Application
//    {
//        public 
//        protected override void OnStartup(StartupEventArgs e)
//        {
//            base.OnStartup(e);

//            // Create the main window
//            ProductList mainWindow = new ProductList();

//            // Show the main window
//            mainWindow.Show();
//        }
//    }
//}
