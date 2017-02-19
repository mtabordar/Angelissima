namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RegistryConfiguration
    {
        public static void ConfigureRegistryEntity(EntityTypeBuilder<Registry> entityBuilder)
        {
            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(r => r.Quantity).IsRequired();
            entityBuilder.Property(r => r.SaleDate).IsRequired();
            entityBuilder.Property(r => r.Price).IsRequired();
        }
    }
}
