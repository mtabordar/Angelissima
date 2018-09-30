namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InventoryItemConfiguration
    {
        public static void ConfigureInventoryItemEntity(EntityTypeBuilder<InventoryItem> entityBuilder)
        {
            entityBuilder.ToTable("inventoryitem");
            entityBuilder.HasOne(i => i.Product);
            entityBuilder.HasKey(i => i.Id);
            entityBuilder.Property(i => i.Id).HasColumnName("id");
            entityBuilder.Property(i => i.ProductId).HasColumnName("productid");
            entityBuilder.Property(i => i.RegistrationDate).HasColumnName("registrationdate").IsRequired();
        }

        public static void ConfigureInventoryItemStatusEntity(EntityTypeBuilder<InventoryItemStatus> entityBuilder)
        {
            entityBuilder.ToTable("inventoryitemstatus");
            entityBuilder.HasKey(i => i.Id);
            entityBuilder.Property(i => i.Id).HasColumnName("id");
            entityBuilder.Property(i => i.Name).HasColumnName("name").IsRequired();
            entityBuilder.Property(i => i.Description).HasColumnName("description").IsRequired();
        }
    }
}
