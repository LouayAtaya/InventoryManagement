using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class SaleOrderItemConfiguration : IEntityTypeConfiguration<SaleOrderItem>
    {
        public void Configure(EntityTypeBuilder<SaleOrderItem> builder)
        {
            builder.ToTable("SaleOrder_Items");

            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Item)
                .WithMany(i => i.SaleOrderItems)
                .HasForeignKey(o => o.ItemId);

            builder.Property(o => o.ItemId)
                .HasColumnName("Item_Id");

            builder.HasOne(o => o.SaleOrder)
                .WithMany(so => so.SaleOrderItems)
                .HasForeignKey(o => o.SaleOrderId);

            builder.Property(o => o.SaleOrderId)
                .HasColumnName("SaleOrder_Id");

            builder.Property(o => o.price)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(o => o.Quantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(o => o.SubTotal)
                .IsRequired()
                .HasDefaultValue(0);
            
        }
    }
}
