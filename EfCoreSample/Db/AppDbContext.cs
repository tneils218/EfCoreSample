using EfCoreSample.Db.EntityTypeConfigurations;
using EfCoreSample.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSample.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order>Orders { get; set; } = null!;

        public DbSet<OrderItem> OrderItems { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
