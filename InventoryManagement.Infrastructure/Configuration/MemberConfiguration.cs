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
    class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Image)
                .HasMaxLength(500);

            builder.Property(m => m.Introduction)
                .HasMaxLength(200);

            builder.Property(m => m.UserId)
                .HasColumnName("User_Id")
                .IsRequired();

            builder.HasOne(m => m.User)
                .WithOne(u => u.Member)
                .HasForeignKey<Member>(m => m.UserId);
        }
    }
}
