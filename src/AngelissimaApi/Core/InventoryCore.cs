namespace AngelissimaApi.Core
{
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class InventoryCore : IInventoryCore
    {
        private IInventoryRepository _inventoryRepository;
        private ISaleRepository _saleRepository;

        public InventoryCore(IInventoryRepository inventoryRepository, ISaleRepository saleRepository)
        {
            _inventoryRepository = inventoryRepository;
            _saleRepository = saleRepository;
        }

        public void Add(Inventory item)
        {
            _inventoryRepository.Add(item);
        }

        public Inventory Find(int id)
        {
            Inventory inv = _inventoryRepository.Find(id);
            inv.Quantity = _inventoryRepository.GetTotalInventoryProductQuantity(id) - _saleRepository.GetTotalSalesProductQuantity(id);
            return inv;
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _inventoryRepository.GetAll();
        }

        public int GetTotalInventoryProductQuantity(int id)
        {
            return _inventoryRepository.GetTotalInventoryProductQuantity(id);
        }

        public void Remove(int id)
        {
            _inventoryRepository.Remove(id);
        }

        public void Update(Inventory item)
        {
            _inventoryRepository.Update(item);
        }
    }
}
