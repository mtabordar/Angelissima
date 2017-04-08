namespace AngelissimaApi.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class CodeRepository : BaseRepository<Code>, ICodeRepository
    {
        private AngelContext _context;

        public CodeRepository(AngelContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Code> GetCodesByProduct(int productId)
        {
            return _context.Codes.Where(c => c.ProductId == productId);
        }
    }
}
