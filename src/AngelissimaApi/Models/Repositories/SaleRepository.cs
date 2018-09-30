namespace AngelissimaApi.Models.Repositories
{
    using System;
    using System.Linq;
    using AngelissimaApi.Models.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private AngelContext context;

        public SaleRepository(AngelContext context): base(context)
        {
            this.context = context;
        }

        public override void Add(Sale sale)
        {
            context.Sales.Add(sale);
        }

        public int GetTotalSalesProductQuantity(int productId)
        {
            //return _context.Sales.Include(s => s.SaleItems).SelectMany(s => s.SaleItems).Where(si => si.InventoryItemId == productId).Sum(si => si.Quantity);
            throw new NotImplementedException();
        }
    }
}
