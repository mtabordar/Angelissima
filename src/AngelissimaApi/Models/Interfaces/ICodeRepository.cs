namespace AngelissimaApi.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IBarCodeRepository : IBaseRepository<BarCode>
    {
        IEnumerable<BarCode> GetCodesByProduct(int productId);
    }
}
