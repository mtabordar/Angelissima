namespace AngelissimaApi.Models.Interfaces
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        int GetTotalInventoryProductQuantity(int productId);
    }
}
