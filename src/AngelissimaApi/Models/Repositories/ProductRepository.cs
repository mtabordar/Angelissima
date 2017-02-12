namespace AngelissimaApi.Models.Repositories
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductRepository : IProductRepository
    {
        private AngelContext context;

        public ProductRepository(AngelContext context)
        {
            this.context = context;
        }

        public void Add(Product item)
        {
            context.Products.Add(item);
            context.SaveChanges();
        }

        public Product Find(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Include(c => c.Codes).ToList();
        }

        public void Remove(int id)
        {
            context.Products.Remove(Find(id));
            context.SaveChanges();
        }

        public void Update(Product item)
        {
            context.Products.Update(item);
            context.SaveChanges();
        }
    }
}
