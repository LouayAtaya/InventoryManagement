
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Configuration
{
    class WarehouseItemConfiguration : IEntityTypeConfiguration<WarehouseItem>
    {
        public void Configure(EntityTypeBuilder<WarehouseItem> builder)
        {
            builder.ToTable("Warehouse_Items");

            builder.HasKey(wi => new { wi.ItemId, wi.WarehouseId });

            builder.Property(wi => wi.ItemId).HasColumnName("Item_Id");

            builder.Property(wi => wi.WarehouseId).HasColumnName("Warehouse_Id");

            builder.Property(wi => wi.Quantity).HasDefaultValue(0);

            builder.HasOne(wi => wi.Item)
                .WithMany(i => i.WarehouseItems)
                .HasForeignKey(wi=>wi.ItemId);

            builder.HasOne(wi=>wi.Warehouse)
                .WithMany(w=>w.WarehouseItems)
                .HasForeignKey(wi => wi.WarehouseId);
        }
    }
}
