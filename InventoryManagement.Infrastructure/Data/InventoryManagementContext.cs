using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Data
{
    public class InventoryManagementContext : DbContext
    {

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SaleOrderItem> SaleOrderItems { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }

        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) 
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemImageConfiguration());
            modelBuilder.ApplyConfiguration(new ItemCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseItemConfiguration());
            modelBuilder.ApplyConfiguration(new SaleOrderConfiguration());
            modelBuilder.ApplyConfiguration(new SaleOrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());


        }
    }
}
