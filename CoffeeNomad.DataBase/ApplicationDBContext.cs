using CoffeeNomad.DataBase.Configurations;
using CoffeeNomad.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNomad.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Order> orders {  get; set; }

        public DbSet<ProductMenu> products { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Cart> carts { get; set; }

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
