using EfCoreSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Db.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>

    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("tbl_order");

            builder.Property(e => e.CreatedAt).HasColumnName("created_at");

            builder.HasMany(e => e.Items)
                .WithOne()
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("order_item_fk");
 
        }
    }
}
