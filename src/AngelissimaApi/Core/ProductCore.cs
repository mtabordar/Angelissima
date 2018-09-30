namespace AngelissimaApi.Core
{
    using System.Collections.Generic;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using AngelissimaApi.ViewModels;
    using AutoMapper;

    public class ProductCore : IProductCore
    {
        private IBarCodeRepository codeRepository;
        private IProductRepository productRepository;
        private IInventoryItemCore inventoryCore;
        private IMapper mapper;

        public ProductCore(IProductRepository productRepository, IBarCodeRepository codeRepository, IInventoryItemCore inventoryCore, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.codeRepository = codeRepository;
            this.inventoryCore = inventoryCore;
            this.mapper = mapper;
        }

        public void Add(ProductViewModel item)
        {
            Product product = mapper.Map<Product>(item);

            productRepository.Add(product);
            productRepository.SaveChanges();
        }

        public ProductViewModel Find(int id)
        {
            ProductViewModel productView = mapper.Map<ProductViewModel>(productRepository.Find(id));

            return productView;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<ProductViewModel>>(productRepository.GetAll());
        }

        public void Remove(int id)
        {
            productRepository.Remove(id);
            productRepository.SaveChanges();
        }

        public void Update(ProductViewModel item)
        {
            Product product = mapper.Map<Product>(item);

            IEnumerable<BarCode> codes = codeRepository.GetCodesByProduct(product.Id);

            foreach (BarCode code in codes)
            {
                codeRepository.Remove(code);
            }

            codeRepository.SaveChanges();

            productRepository.Update(product);
            codeRepository.AddRange(product.BarCodes);

            productRepository.SaveChanges();
        }
    }
}
