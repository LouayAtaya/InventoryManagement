﻿using InventoryManagement.Domain.Entities;
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

            builder.Property(o => o.TotalOrderPrice)
                .IsRequired()
                .HasDefaultValue(0);


        }
    }
}