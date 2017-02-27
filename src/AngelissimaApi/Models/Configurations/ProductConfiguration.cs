namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class ProductConfiguration
    {
        public static void ConfigureProductEntity(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.ToTable("Product").HasKey(p => p.Id);
            entityBuilder.HasOne(p => p.BarCodes);
            entityBuilder.Property(p => p.Name).IsRequired();
            entityBuilder.Property(p => p.UnitPrice).IsRequired();
            entityBuilder.Property(p => p.SalePrice).IsRequired();
            entityBuilder.Property(p => p.MinimunQuantity).HasDefaultValue(0);
        }
    }
}
