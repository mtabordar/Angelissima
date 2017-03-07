namespace AngelissimaApi.Models.Repositories
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InventoryRepository : IInventoryRepository
    {
        private AngelContext _context;

        public InventoryRepository(AngelContext context)
        {
            this._context = context;
        }

        public void Add(Inventory item)
        {
            _context.Inventory.Add(item);
            _context.Entry(item.Product).State = EntityState.Unchanged;
            _context.Entry(item.Product.BarCodes).State = EntityState.Unchanged;
            _context.SaveChanges();
        }

        public Inventory Find(int id)
        {
            return _context.Inventory
                .Include(i => i.Product)
                .ThenInclude(p => p.BarCodes)
                .FirstOrDefault(i => i.ProductId == id);            
        }

        public IEnumerable<Inventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetTotalInventoryProductQuantity(int productId)
        {
            return _context.Inventory.Where(i => i.ProductId == productId).Sum(ti => ti.Quantity);                
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory item)
        {
            throw new NotImplementedException();
        }
    }
}
