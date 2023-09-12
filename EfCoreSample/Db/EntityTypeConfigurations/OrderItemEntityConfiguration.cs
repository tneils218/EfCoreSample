using EfCoreSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Db.EntityTypeConfigurations
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("tbl_order_item");

            builder.Property(e => e.ProductPrice)
               .HasColumnName("order_item_name");

            builder.Property(e => e.Quantity)
             .HasColumnName("order_item_quantity");

            builder.Property(e => e.OrderId)
             .HasColumnName("order_id");
        }
    }
}
