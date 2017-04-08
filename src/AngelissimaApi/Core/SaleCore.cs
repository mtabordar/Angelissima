namespace AngelissimaApi.Core
{
    using AngelissimaApi.Core.Interfaces;
    using System.Collections.Generic;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;

    public class SaleCore : ISaleCore
    {
        private ISaleRepository _saleRepository;

        public SaleCore(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public void Add(Sale item)
        {
            _saleRepository.Add(item);
        }

        public Sale Find(int id)
        {
            return _saleRepository.Find(id);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _saleRepository.GetAll();
        }

        public void Remove(int id)
        {
            _saleRepository.Remove(id);
        }

        public void Update(Sale item)
        {
            _saleRepository.Update(item);
        }
    }
}
