namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfiguration
    {
        public static void ConfigureSaleEntity(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.ToTable("sale");
            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(s => s.Id).HasColumnName("id");
            entityBuilder.Property(r => r.SaleDate).HasColumnName("saledate").IsRequired();
            entityBuilder.Property(r => r.TotalPrice).HasColumnName("totalprice").IsRequired();
            entityBuilder.HasMany(a => a.SaleItems).WithOne(s => s.Sale);
        }

        public static void ConfigureSaleItemEntity(EntityTypeBuilder<SaleItem> entityBuilder)
        {
            entityBuilder.ToTable("saleitem");
            entityBuilder.Property(si => si.InventoryItemId).HasColumnName("inventoryitemid");
            entityBuilder.Property(si => si.SaleId).HasColumnName("saleid");
            entityBuilder.Property(si => si.Price).HasColumnName("price");
            entityBuilder.HasKey(c => new { c.InventoryItemId, c.SaleId });
        }
    }
}
