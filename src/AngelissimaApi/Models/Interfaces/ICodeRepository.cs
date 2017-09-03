namespace AngelissimaApi.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ICodeRepository : IBaseRepository<Code>
    {
        IEnumerable<Code> GetCodesByProduct(int productId);
    }
}
