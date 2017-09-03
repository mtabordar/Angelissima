namespace AngelissimaApi.Models
{
    using Configurations;
    using Microsoft.AspNetCore.Hosting;
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
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ProductConfiguration.ConfigureProductEntity);
            modelBuilder.Entity<Code>(CodeConfiguration.ConfigureCodeEntity);
            modelBuilder.Entity<Inventory>(InventoryConfiguration.ConfigureInventoryEntity);
            modelBuilder.Entity<Sale>(SaleConfiguration.ConfigureSaleEntity);
            modelBuilder.Entity<SaleItem>(SaleConfiguration.ConfigureSaleItemEntity);
            modelBuilder.Entity<Report>();
        }

        public void EnsureSeedData()
        {
            if (!this.Products.Any())
            {
                this.Products.Add(new Product { Description = "Product 1", MinimunQuantity = 1, Name = "Product 1", SalePrice = 2500, UnitPrice = 2000, BarCodes = new Code { BarCode = "1234" } });
                this.Products.Add(new Product { Description = "Product 2", MinimunQuantity = 1, Name = "Product 2", SalePrice = 3000, UnitPrice = 3500, BarCodes = new Code { BarCode = "2345" } });
                this.Products.Add(new Product { Description = "Product 3", MinimunQuantity = 1, Name = "Product 3", SalePrice = 8000, UnitPrice = 11000, BarCodes = new Code { BarCode = "3456" } });
                this.Products.Add(new Product { Description = "Product 4", MinimunQuantity = 1, Name = "Product 4", SalePrice = 5500, UnitPrice = 6200, BarCodes = new Code { BarCode = "4567" } });

                this.SaveChanges();
            }

            if (!this.Inventory.Any())
            {
                this.Inventory.Add(new Inventory { ProductId = 1, Quantity = 8, RegistrationDate = DateTime.Now });
                this.Inventory.Add(new Inventory { ProductId = 2, Quantity = 3, RegistrationDate = DateTime.Now });
                this.Inventory.Add(new Inventory { ProductId = 3, Quantity = 6, RegistrationDate = DateTime.Now });
                this.Inventory.Add(new Inventory { ProductId = 4, Quantity = 3, RegistrationDate = DateTime.Now });
                this.Inventory.Add(new Inventory { ProductId = 1, Quantity = 3, RegistrationDate = DateTime.Now });
                this.Inventory.Add(new Inventory { ProductId = 2, Quantity = 2, RegistrationDate = DateTime.Now });

                this.SaveChanges();
            }

            if (!this.Sales.Any())
            {
                List<SaleItem> lstSaleItems = new List<SaleItem>();
                lstSaleItems.Add(new SaleItem { ProductId = 1, Quantity = 2, price = 2500 });
                lstSaleItems.Add(new SaleItem { ProductId = 2, Quantity = 1, price = 3000 });
                this.Sales.Add(new Sale { TotalPrice = 8000, SaleDate = DateTime.Now, SaleItems = lstSaleItems });

                lstSaleItems = new List<SaleItem>();
                lstSaleItems.Add(new SaleItem { ProductId = 2, Quantity = 2, price = 3000 });
                lstSaleItems.Add(new SaleItem { ProductId = 3, Quantity = 1, price = 8000 });
                this.Sales.Add(new Sale { TotalPrice = 14000, SaleDate = DateTime.Now, SaleItems = lstSaleItems });

                lstSaleItems = new List<SaleItem>();
                lstSaleItems.Add(new SaleItem { ProductId = 4, Quantity = 1, price = 5500 });
                this.Sales.Add(new Sale { TotalPrice = 5500, SaleDate = DateTime.Now, SaleItems = lstSaleItems });

                lstSaleItems = new List<SaleItem>();
                lstSaleItems.Add(new SaleItem { ProductId = 1, Quantity = 3, price = 2500 });
                lstSaleItems.Add(new SaleItem { ProductId = 3, Quantity = 1, price = 8000 });
                this.Sales.Add(new Sale { TotalPrice = 15500, SaleDate = DateTime.Now, SaleItems = lstSaleItems });

                lstSaleItems = new List<SaleItem>();
                lstSaleItems.Add(new SaleItem { ProductId = 3, Quantity = 1, price = 8000 });
                this.Sales.Add(new Sale { TotalPrice = 8000, SaleDate = DateTime.Now, SaleItems = lstSaleItems });

                lstSaleItems = new List<SaleItem>();
                lstSaleItems.Add(new SaleItem { ProductId = 2, Quantity = 2, price = 3000 });
                lstSaleItems.Add(new SaleItem { ProductId = 4, Quantity = 1, price = 5500 });
                this.Sales.Add(new Sale { TotalPrice = 11500, SaleDate = DateTime.Now, SaleItems = lstSaleItems });

                this.SaveChanges();
            }
        }
    }
}
