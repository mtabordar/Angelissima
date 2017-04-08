namespace AngelissimaApi.Core.Interfaces
{
    using AngelissimaApi.Models;

    public interface IInventoryCore : IBaseCore<Inventory>
    {
        int GetTotalInventoryProductQuantity(int id);
    }
}
