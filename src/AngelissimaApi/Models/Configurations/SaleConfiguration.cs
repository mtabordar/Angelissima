namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfiguration
    {
        public static void ConfigureSaleEntity(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.ToTable("Sale").HasKey(p => p.Id);
            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(r => r.SaleDate).IsRequired();
            entityBuilder.Property(r => r.TotalPrice).IsRequired();
        }
    }
}
