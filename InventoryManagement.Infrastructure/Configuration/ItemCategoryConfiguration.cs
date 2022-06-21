using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Configuration
{
    class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.ToTable("ItemCategories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.Property(c => c.Image)
                .HasMaxLength(500);

            builder.Property(i => i.ParentCategoryId)
                .HasColumnName("ParentCategory_Id");

            builder.HasIndex(i => i.Name).IsUnique();

            builder.Property(i => i.IsActive).HasDefaultValue(true);

            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            builder.HasMany(c => c.Items)
                .WithOne(i => i.ItemCategory)
                .HasForeignKey(i => i.ItemCategoryId);

        }
    }
}
