using Microsoft.EntityFrameworkCore;
using PZ_User_Panel_console.Data.Models;

namespace PZ_User_Panel_console.Context
{
    public class StoreDBContext: DbContext
    {
        public StoreDBContext(DbContextOptions options): base(options) 
        {
        }
        public DbSet<Category> Category {  get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> User_ { get; set; }
    }
}
