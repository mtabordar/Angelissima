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
            return _context.Products.Include(c => c.BarCode).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(c => c.BarCode).ToList();
        }

        public void Remove(int id)
        {
            _context.Products.Remove(Find(id));
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            Code cod = _context.Codes.FirstOrDefault(c => c.ProductId == item.Id);
            _context.Codes.Remove(cod);

            _context.Codes.Add(item.BarCode);

            _context.Products.Update(item);

            _context.SaveChanges();
        }
    }
}
