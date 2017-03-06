namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InventoryConfiguration
    {
        public static void ConfigureInventoryEntity(EntityTypeBuilder<Inventory> entityBuilder)
        {
            entityBuilder.ToTable("inventory");
            entityBuilder.HasOne(i => i.Product);
            entityBuilder.HasKey(i => i.Id);
            entityBuilder.Property(i => i.Id).HasColumnName("id");
            entityBuilder.Property(i => i.ProductId).HasColumnName("productid");
            entityBuilder.Property(i => i.Quantity).HasColumnName("quantity").IsRequired();
            entityBuilder.Property(i => i.RegistrationDate).HasColumnName("registrationdate").IsRequired();
        }
    }
}
