namespace AngelissimaApi.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class AngelContext : DbContext   
    {
        public AngelContext(DbContextOptions<AngelContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Registry> Registry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
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
