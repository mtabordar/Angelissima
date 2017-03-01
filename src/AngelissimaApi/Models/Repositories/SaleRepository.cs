namespace AngelissimaApi.Models.Repositories
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class SaleRepository : ISaleRepository
    {
        private AngelContext _context;

        public SaleRepository(AngelContext context)
        {
            this._context = context;
        }

        public void Add(Sale sale)
        {
            _context.Sales.Add(sale);
            foreach (SaleItem saleItem in sale.SaleItems)
            {
                _context.Entry(saleItem.Product).State = EntityState.Unchanged;
                _context.Entry(saleItem.Product.BarCodes).State = EntityState.Unchanged;
            }

            _context.SaveChanges();
        }

        public Sale Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Sale item)
        {
            throw new NotImplementedException();
        }
    }
}
