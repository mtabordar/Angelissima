namespace AngelissimaApi.Core
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class ProductCore : IProductCore
    {
        private ICodeRepository _codeRepository;
        private IProductRepository _productRepository;

        public ProductCore(IProductRepository productRepository, ICodeRepository codeRepository)
        {
            _productRepository = productRepository;
            _codeRepository = codeRepository;
        }

        public void Add(Product item)
        {
            _productRepository.Add(item);
            _productRepository.SaveChanges();
        }

        public Product Find(int id)
        {
            return _productRepository.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Remove(int id)
        {
            _productRepository.Remove(id);
            _productRepository.SaveChanges();
        }

        public void Update(Product item)
        {
            IEnumerable<Code> codes = _codeRepository.GetCodesByProduct(item.Id);

            foreach (Code code in codes)
            {
                _codeRepository.Remove(code);
            }

            _codeRepository.SaveChanges();

            _productRepository.Update(item);
            _codeRepository.Add(item.BarCodes);

            _productRepository.SaveChanges();            
        }
    }
}
