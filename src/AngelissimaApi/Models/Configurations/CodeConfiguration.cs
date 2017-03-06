namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CodeConfiguration
    {
        public static void ConfigureCodeEntity(EntityTypeBuilder<Code> entityBuilder)
        {
            entityBuilder.ToTable("code").HasKey(c => new { c.ProductId, c.BarCode });
            entityBuilder.Property(c => c.BarCode).HasColumnName("barcode");
            entityBuilder.Property(c => c.ProductId).HasColumnName("productid");
        }
    }
}
