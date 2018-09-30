namespace AngelissimaApi.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AngelissimaApi.Models.Interfaces;
    using AngelissimaApi.Shared.Enums;
    using Microsoft.EntityFrameworkCore;

    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        private AngelContext context;

        public InventoryItemRepository(AngelContext context) : base(context)
        {
            this.context = context;
        }

        public override InventoryItem Find(int id)
        {
            return context.Inventory
                .Include(i => i.Product)
                .ThenInclude(p => p.BarCodes)
                .FirstOrDefault(i => i.ProductId == id);
        }

        public IEnumerable<InventoryItem> TaleInventoryItems(int id, int numberOfItems)
        {
            return context.Inventory
                .Include(i => i.Product)
                .ThenInclude(p => p.BarCodes)
                .Where(i => i.ProductId == id).Take(numberOfItems).ToList();
        }

        public int GetInventoryByProduct(int productId, InventoryItemStatusType inventoryItemStatusType)
        {
            int AvailableType = (int)inventoryItemStatusType;
            return context.Inventory.Count(i => i.ProductId == productId && i.InventoryItemStatusId == AvailableType);            
        }
    }
}
