
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Configuration
{
    class ItemImageConfiguration : IEntityTypeConfiguration<ItemImage>
    {
        public void Configure(EntityTypeBuilder<ItemImage> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasMaxLength(50);

            builder.Property(i => i.Description)
                .HasMaxLength(500);

            builder.Property(i => i.Url)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(i => i.ItemId)
                .HasColumnName("Item_Id");

        }
    }
}
