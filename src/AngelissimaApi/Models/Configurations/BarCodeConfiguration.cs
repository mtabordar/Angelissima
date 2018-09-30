namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class BarCodeConfiguration
    {
        public static void ConfigureBarCodeEntity(EntityTypeBuilder<BarCode> entityBuilder)
        {
            entityBuilder.ToTable("barcode").HasKey(c => new { c.ProductId, c.Code });
            entityBuilder.Property(c => c.Code).HasColumnName("code");
            entityBuilder.Property(c => c.ProductId).HasColumnName("productid");
        }
    }
}
