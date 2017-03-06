namespace AngelissimaApi.Models
{
    using Configurations;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class AngelContext : DbContext
    {
        private IHostingEnvironment _env;

        public AngelContext(DbContextOptions<AngelContext> options, IHostingEnvironment env) : base(options)
        {
            _env = env;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Code> Codes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ProductConfiguration.ConfigureProductEntity);
            modelBuilder.Entity<Code>(CodeConfiguration.ConfigureCodeEntity);
            modelBuilder.Entity<Inventory>(InventoryConfiguration.ConfigureInventoryEntity);
            modelBuilder.Entity<Sale>(SaleConfiguration.ConfigureSaleEntity);
            modelBuilder.Entity<SaleItem>(SaleConfiguration.ConfigureSaleItemEntity);
        }

        public void EnsureSeedData()
        {
            if (_env.IsDevelopment())
            {
                if (!this.Products.Any())
                {
                    this.Products.Add(new Product { Description = "Product 1", MinimunQuantity = 1, Name = "Product 1", SalePrice = 2500, UnitPrice = 2000, BarCodes = new Code { BarCode = "1234" } });
                    this.Products.Add(new Product { Description = "Product 2", MinimunQuantity = 1, Name = "Product 2", SalePrice = 3000, UnitPrice = 3500, BarCodes = new Code { BarCode = "2345" } });
                    this.Products.Add(new Product { Description = "Product 3", MinimunQuantity = 1, Name = "Product 3", SalePrice = 8000, UnitPrice = 11000, BarCodes = new Code { BarCode = "3456" } });
                    this.Products.Add(new Product { Description = "Product 4", MinimunQuantity = 1, Name = "Product 4", SalePrice = 5500, UnitPrice = 6200, BarCodes = new Code { BarCode = "4567" } });

                    this.SaveChanges();
                }

                if(!this.Inventory.Any())
                {
                    this.Inventory.Add(new Inventory { ProductId = 1, Quantity = 8, RegistrationDate = DateTime.Now });
                    this.Inventory.Add(new Inventory { ProductId = 2, Quantity = 3, RegistrationDate = DateTime.Now });
                    this.Inventory.Add(new Inventory { ProductId = 3, Quantity = 6, RegistrationDate = DateTime.Now });
                    this.Inventory.Add(new Inventory { ProductId = 4, Quantity = 3, RegistrationDate = DateTime.Now });
                    this.Inventory.Add(new Inventory { ProductId = 1, Quantity = 3, RegistrationDate = DateTime.Now });
                    this.Inventory.Add(new Inventory { ProductId = 2, Quantity = 2, RegistrationDate = DateTime.Now });

                    this.SaveChanges();
                }
            }
        }
    }
}
