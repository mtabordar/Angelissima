namespace AngelissimaApi.Core
{
    using System.Collections.Generic;
    using AutoMapper;
    using Interfaces;
    using Models;
    using Models.Interfaces;
    using ViewModels;

    public class InventoryCore : IInventoryCore
    {
        private IInventoryRepository _inventoryRepository;
        private ISaleRepository _saleRepository;
        private IMapper _mapper;

        public InventoryCore(IInventoryRepository inventoryRepository, ISaleRepository saleRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public void Add(InventoryViewModel item)
        {
            Inventory inventory = _mapper.Map<Inventory>(item);
            _inventoryRepository.Add(inventory);
            _inventoryRepository.SaveChanges();
        }

        public InventoryViewModel Find(int id)
        {
            InventoryViewModel inventory = _mapper.Map<InventoryViewModel>(_inventoryRepository.Find(id));

            if (inventory != null)
            {                
                inventory.Product.AvailableQuantity = GetAvailableProductQuantity(id);
            }

            return inventory;
        }

        public IEnumerable<InventoryViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<InventoryViewModel>>(_inventoryRepository.GetAll());
        }

        public int GetAvailableProductQuantity(int productId)
        {
            return _inventoryRepository.GetTotalInventoryProductQuantity(productId) - _saleRepository.GetTotalSalesProductQuantity(productId);
        }

        public int GetTotalInventoryProductQuantity(int productiId)
        {
            return _inventoryRepository.GetTotalInventoryProductQuantity(productiId);
        }

        public void Remove(int id)
        {
            _inventoryRepository.Remove(id);
            _inventoryRepository.SaveChanges();
        }

        public void Update(InventoryViewModel item)
        {
            Inventory inventory = _mapper.Map<Inventory>(item);
            _inventoryRepository.Update(inventory);
            _inventoryRepository.SaveChanges();
        }        
    }
}
