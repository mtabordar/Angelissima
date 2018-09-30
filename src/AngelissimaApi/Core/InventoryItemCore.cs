namespace AngelissimaApi.Core
{
    using System.Collections.Generic;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using AngelissimaApi.Shared.Enums;
    using AngelissimaApi.ViewModels;
    using AutoMapper;

    public class InventoryItemCore : IInventoryItemCore
    {
        private IInventoryItemRepository _inventoryRepository;
        private ISaleRepository _saleRepository;
        private IMapper _mapper;

        public InventoryItemCore(IInventoryItemRepository inventoryRepository, ISaleRepository saleRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public void Add(InventoryItemViewModel inventoryViewModel)
        {
            InventoryItem inventory = _mapper.Map<InventoryItem>(inventoryViewModel);
            for(int i = 0; i < inventoryViewModel.Quantity; i++)
            {
                _inventoryRepository.Add(new InventoryItem {
                    ProductId = inventoryViewModel.ProductId,
                    RegistrationDate = inventoryViewModel.RegistrationDate,
                    InventoryItemStatusId = (int)InventoryItemStatusType.Available
                });
            }
            
            _inventoryRepository.SaveChanges();
        }

        public InventoryItemViewModel Find(int id)
        {
            InventoryItemViewModel inventory = _mapper.Map<InventoryItemViewModel>(_inventoryRepository.Find(id));

            if (inventory != null)
            {                
                inventory.AvailableQuantity = GetAvailableProductQuantity(id);
            }

            return inventory;
        }

        public IEnumerable<InventoryItemViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<InventoryItemViewModel>>(_inventoryRepository.GetAll());
        }

        private int GetAvailableProductQuantity(int productId)
        {
            return _inventoryRepository.GetInventoryByProduct(productId, InventoryItemStatusType.Available);
        }

        public void Remove(int id)
        {
            _inventoryRepository.Remove(id);
            _inventoryRepository.SaveChanges();
        }

        public void Update(InventoryItemViewModel item)
        {
            InventoryItem inventory = _mapper.Map<InventoryItem>(item);
            _inventoryRepository.Update(inventory);
            _inventoryRepository.SaveChanges();
        }        
    }
}
