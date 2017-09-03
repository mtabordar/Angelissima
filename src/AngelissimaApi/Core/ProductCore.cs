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
        private ICodeRepository _codeRepository;
        private IProductRepository _productRepository;
        private IInventoryCore _inventoryCore;
        private IMapper _mapper;

        public ProductCore(IProductRepository productRepository, ICodeRepository codeRepository, IInventoryCore inventoryCore, IMapper mapper)
        {
            _productRepository = productRepository;
            _codeRepository = codeRepository;
            _inventoryCore = inventoryCore;
            _mapper = mapper;
        }

        public void Add(ProductViewModel item)
        {
            Product product = _mapper.Map<Product>(item);

            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }

        public ProductViewModel Find(int id)
        {
            ProductViewModel productView = _mapper.Map<ProductViewModel>(_productRepository.Find(id));
            productView.AvailableQuantity = _inventoryCore.GetAvailableProductQuantity(id);
            return productView;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public void Remove(int id)
        {
            _productRepository.Remove(id);
            _productRepository.SaveChanges();
        }

        public void Update(ProductViewModel item)
        {
            Product product = _mapper.Map<Product>(item);

            IEnumerable<Code> codes = _codeRepository.GetCodesByProduct(product.Id);

            foreach (Code code in codes)
            {
                _codeRepository.Remove(code);
            }

            _codeRepository.SaveChanges();

            _productRepository.Update(product);
            _codeRepository.Add(product.BarCodes);

            _productRepository.SaveChanges();
        }
    }
}
