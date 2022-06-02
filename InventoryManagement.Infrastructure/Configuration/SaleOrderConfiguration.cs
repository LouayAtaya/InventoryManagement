using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Configuration
{
    class SaleOrderConfiguration : IEntityTypeConfiguration<SaleOrder>
    {
        public void Configure(EntityTypeBuilder<SaleOrder> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Description)
                .HasMaxLength(500);

            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(o => o.SaleOrderStatus)
                .IsRequired()
                .HasDefaultValue(SaleOrderStatus.Incomplet);

            builder.Property(o => o.TotalOrderPrice)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(o => o.CustomerId).HasColumnName("Customer_Id");
            builder.Property(o => o.WarehouseId).HasColumnName("Warehouse_Id");

            builder.HasOne(o => o.Warehouse)
                .WithMany(w => w.SaleOrders)
                .HasForeignKey(o => o.WarehouseId);
        }
    }
}
