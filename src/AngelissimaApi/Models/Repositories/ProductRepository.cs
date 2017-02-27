namespace AngelissimaApi.Models.Repositories
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductRepository : IProductRepository
    {
        private AngelContext _context;

        public ProductRepository(AngelContext context)
        {
            this._context = context;
        }

        public void Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public Product Find(int id)
        {
            return _context.Products.Include(c => c.BarCodes).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(c => c.BarCodes).ToList();
        }

        public void Remove(int id)
        {
            _context.Products.Remove(Find(id));
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            IEnumerable<Code> codes = _context.Codes.Where(c => c.ProductId == item.Id);

            foreach(Code code in codes)
            {
                _context.Codes.Remove(code);
            }

            _context.SaveChanges();

            _context.Codes.Add(item.BarCodes);
            _context.Products.Update(item);
            _context.SaveChanges();
        }
    }
}
