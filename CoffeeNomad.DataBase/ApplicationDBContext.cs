using CoffeeNomad.DataBase.Configurations;
using CoffeeNomad.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNomad.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Order> orders;

        public DbSet<ProductMenu> products;

        public DbSet<User> users;

        public DbSet<Cart> carts;

        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
