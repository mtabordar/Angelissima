using System.Collections.Generic;
using AngelissimaApi.Shared.Enums;

namespace AngelissimaApi.Models.Interfaces
{
    public interface IInventoryItemRepository : IBaseRepository<InventoryItem>
    {
        IEnumerable<InventoryItem> TaleInventoryItems(int id, int numberOfItems);
        int GetInventoryByProduct(int productId, InventoryItemStatusType inventoryItemStatusType);        
    }
}
