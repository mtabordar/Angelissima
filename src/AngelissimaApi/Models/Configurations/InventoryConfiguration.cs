namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InventoryConfiguration
    {
        public static void ConfigureInventoryEntity(EntityTypeBuilder<Inventory> entityBuilder)
        {
            entityBuilder.HasOne(i => i.Product);
            entityBuilder.HasKey(i => i.Id);
            entityBuilder.Property(i => i.Quantity).IsRequired();
            entityBuilder.Property(i => i.RegistrationDate).IsRequired();
        }
    }
}
