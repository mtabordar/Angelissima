namespace AngelissimaApi.Models
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AngelContext : DbContext
    {
        public AngelContext(DbContextOptions<AngelContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<BarCode> BarCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ProductConfiguration.ConfigureProductEntity);
            modelBuilder.Entity<BarCode>(BarCodeConfiguration.ConfigureBarCodeEntity);
            modelBuilder.Entity<InventoryItem>(InventoryItemConfiguration.ConfigureInventoryItemEntity);
            modelBuilder.Entity<InventoryItemStatus>(InventoryItemConfiguration.ConfigureInventoryItemStatusEntity);
            modelBuilder.Entity<Sale>(SaleConfiguration.ConfigureSaleEntity);
            modelBuilder.Entity<SaleItem>(SaleConfiguration.ConfigureSaleItemEntity);
            modelBuilder.Seed();
        }
    }
}
