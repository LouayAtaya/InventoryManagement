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
    public class ItemOperationConfiguration : IEntityTypeConfiguration<ItemOperation>
    {
        public void Configure(EntityTypeBuilder<ItemOperation> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Description)
                .HasMaxLength(500);

            builder.Property(i => i.Quantity)
                .HasDefaultValue(0);

            builder.Property(i => i.ItemOperationType)
                .IsRequired();

            builder.Property(io => io.ItemId)
                .HasColumnName("Item_Id");

            builder.HasOne(io => io.Item)
                .WithMany(i => i.ItemOperations)
                .HasForeignKey(io => io.ItemId);
        }
    }
}
