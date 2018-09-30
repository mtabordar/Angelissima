namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<InventoryItemStatus>().HasData(
                new InventoryItemStatus { Id = 1, Name = "Available", Description = "Available" },
                new InventoryItemStatus { Id = 2, Name = "Sold", Description = "Sold" },
                new InventoryItemStatus { Id = 3, Name = "Defective", Description = "Defective" },
                new InventoryItemStatus { Id = 4, Name = "NonExistent", Description = "NonExistent" }
             );
        }
    }
}
