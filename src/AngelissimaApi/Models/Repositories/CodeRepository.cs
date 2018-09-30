namespace AngelissimaApi.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AngelissimaApi.Models.Interfaces;

    public class BarCodeRepository : BaseRepository<BarCode>, IBarCodeRepository
    {
        private AngelContext _context;

        public BarCodeRepository(AngelContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<BarCode> GetCodesByProduct(int productId)
        {
            return _context.BarCodes.Where(c => c.ProductId == productId);
        }
    }
}
