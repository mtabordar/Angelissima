namespace AngelissimaApi.Models
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
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
            if (!this.Products.Any())
            {
                //this.Products.Add(new Product
                //{
                //    Name = "Mercado",
                //    IsBasic = true,
                //    PeriodDuration = 1,
                //    Quantity = 1,
                //    BuyDate = DateTime.Now,
                //    UnitPrice = 250000,
                //    UpdatedAt = DateTime.Now
                //});

                this.SaveChanges();
            }
        }
    }
}
