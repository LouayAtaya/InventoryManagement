
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Configuration
{
    class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Code)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.Description)
                .HasMaxLength(500);

            builder.Property(i => i.Inroduction)
                .HasMaxLength(200);

            builder.Property(i => i.TotalQuantity)
                .HasDefaultValue(0);

            builder.Property(i => i.Price)
                .HasDefaultValue(0);

            builder.Property(i => i.ItemType)
                .IsRequired();

            builder.Property(i => i.ItemCategoryId)
                .HasColumnName("ItemCategory_Id")
                .IsRequired();

            builder.HasMany(i => i.ItemImages)
                .WithOne(im => im.Item)
                .HasForeignKey(im => im.ItemId);

        }
    }
}
