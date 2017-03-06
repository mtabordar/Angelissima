namespace AngelissimaApi.Models.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        int GetTotalSalesProductQuantity(int productId);
    }
}
