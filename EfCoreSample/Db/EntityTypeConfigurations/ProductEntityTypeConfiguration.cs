using EfCoreSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Db.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.ToTable("tbl_product"); 

            builder.Property(e => e.Id)
                .HasColumnName("product_id");

            builder.Property(e => e.Name)
                .HasColumnName("product_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("product_price");

            builder.Property(e => e.Description)
               .HasColumnType("text");

            builder.Property(e => e.Quantity)
                .HasColumnName("product_quantity");

            builder.Property(e => e.UpdatedAt)
               .HasColumnName("product_updatedat");

            builder.HasData(CreateProducts());
        }


        private Product[] CreateProducts()
        {
            return new Product[]
            {
                   new Product { Id = 1, Name = "Product 01", Price = 100, Quantity = 10, UpdatedAt = DateTime.Now },
                    new Product { Id =2, Name = "Product 02", Price = 500, Quantity =111, UpdatedAt = DateTime.Now },
                     new Product { Id = 3, Name = "Product 03", Price = 200, Quantity =30, UpdatedAt = DateTime.Now }
            };
        }
    }
}
