namespace AngelissimaApi.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AngelissimaApi.Models.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private AngelContext _context;

        public ProductRepository(AngelContext context) : base(context)
        {
            this._context = context;
        }

        public override Product Find(int id)
        {
            return _context.Products.Include(c => c.BarCodes).FirstOrDefault(p => p.Id == id);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(c => c.BarCodes).ToList();
        }
    }
}
