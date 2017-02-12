namespace AngelissimaApi.Models
{
    using Interfaces;
    using System.Collections.Generic;

    public interface ICodeRepository : IBaseRepository<Code>
    {
        IEnumerable<Code> GetCodes(int productId);
    }
}
