namespace AngelissimaApi.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using AngelissimaApi.Shared.Enums;
    using AngelissimaApi.ViewModels;
    using AutoMapper;

    public class SaleCore : ISaleCore
    {
        private ISaleRepository saleRepository;
        private readonly IInventoryItemRepository inventoryItemRepository;
        private IMapper mapper;

        public SaleCore(ISaleRepository saleRepository, IInventoryItemRepository inventoryItemRepository, IMapper mapper)
        {
            this.saleRepository = saleRepository;
            this.inventoryItemRepository = inventoryItemRepository;
            this.mapper = mapper;
        }

        public void Add(SaleViewModel saleViewModel)
        {
            Sale sale = mapper.Map<Sale>(saleViewModel);

            foreach (SaleItemViewModel saleItemViewModel in saleViewModel.SaleItems)
            {
                List<InventoryItem> inventoryItems = inventoryItemRepository.TaleInventoryItems(saleItemViewModel.ProductId, saleItemViewModel.Quantity).ToList();
                inventoryItems.Select(x => { x.InventoryItemStatusId = (int)InventoryItemStatusType.Sold; return x; });

                for (int i = 0; i < saleItemViewModel.Quantity; i++)
                {
                    sale.SaleItems.Add(new SaleItem
                    {
                        Price = saleItemViewModel.Price,
                        InventoryItem = inventoryItems[i],
                        InventoryItemId = inventoryItems[i].Id
                    });
                }
            }

            saleRepository.Add(sale);
            saleRepository.SaveChanges();
        }

        public SaleViewModel Find(int id)
        {
            return mapper.Map<SaleViewModel>(saleRepository.Find(id));
        }

        public IEnumerable<SaleViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<SaleViewModel>>(saleRepository.GetAll());
        }

        public void Remove(int id)
        {
            saleRepository.Remove(id);
            saleRepository.SaveChanges();
        }

        public void Update(SaleViewModel item)
        {
            Sale sale = mapper.Map<Sale>(item);

            saleRepository.Update(sale);
            saleRepository.SaveChanges();
        }
    }
}
