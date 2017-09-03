namespace AngelissimaApi.Models.Repositories
{
    using System.Linq;
    using AngelissimaApi.Models.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        private AngelContext _context;

        public InventoryRepository(AngelContext context) : base(context)
        {
            this._context = context;
        }

        public override void Add(Inventory item)
        {
            _context.Inventory.Add(item);
            _context.Entry(item.Product).State = EntityState.Unchanged;
            _context.Entry(item.Product.BarCodes).State = EntityState.Unchanged;
        }

        public override Inventory Find(int id)
        {
            return _context.Inventory
                .Include(i => i.Product)
                .ThenInclude(p => p.BarCodes)
                .FirstOrDefault(i => i.ProductId == id);
        }

        public int GetTotalInventoryProductQuantity(int productId)
        {
            return _context.Inventory.Where(i => i.ProductId == productId).Sum(ti => ti.Quantity);
        }
    }
}
