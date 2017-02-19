namespace AngelissimaApi.Models.Interfaces
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        int GetTotalQuantity(int id);
    }
}
