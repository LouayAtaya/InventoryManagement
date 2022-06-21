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
    public class RolePrivilegeConfiguration : IEntityTypeConfiguration<RolePrivilege>
    {
        public void Configure(EntityTypeBuilder<RolePrivilege> builder)
        {
            builder.ToTable("Role_Priviliges");

            builder.HasKey(rp => new { rp.RoleId, rp.PrivilegeId });

            builder.Property(rp => rp.RoleId).HasColumnName("Role_Id");

            builder.Property(rp => rp.PrivilegeId).HasColumnName("Privilege_Id");

            builder.Property(rp => rp.IsActive).HasDefaultValue(true);

            builder.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePrivileges)
                .HasForeignKey(rp => rp.RoleId);

            builder.HasOne(rp => rp.Privilege)
                .WithMany(p => p.RolePrivileges)
                .HasForeignKey(rp => rp.PrivilegeId);
        }
    }
}
