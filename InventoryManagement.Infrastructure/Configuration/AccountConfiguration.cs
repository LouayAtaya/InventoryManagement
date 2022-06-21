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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AccountCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(a => a.AccountCode).IsUnique();

            builder.Property(a => a.Amount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(a => a.AccountType)
                .IsRequired();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.IsActive).HasDefaultValue(true);

            builder.HasIndex(a => a.Name).IsUnique();

            builder.Property(a => a.Description)
                .HasMaxLength(500);

            builder.HasMany(a => a.SaleOrders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

        }
    }
}
