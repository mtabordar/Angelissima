namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfiguration
    {
        public static void ConfigureSaleEntity(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.ToTable("Sale");
            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(r => r.SaleDate).IsRequired();
            entityBuilder.Property(r => r.TotalPrice).IsRequired();
            entityBuilder.HasMany(a => a.SaleItems).WithOne(s => s.Sale);
        }

        public static void ConfigureSaleItemEntity(EntityTypeBuilder<SaleItem> entityBuilder)
        {
            entityBuilder.HasKey(c => new { c.ProductId, c.SaleId });
        }
    }
}
