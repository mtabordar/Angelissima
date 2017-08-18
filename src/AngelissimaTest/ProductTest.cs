namespace AngelissimaTest
{
    using AngelissimaApi;
    using AngelissimaApi.Core;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using AutoMapper;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NSubstitute;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ProductTest
    {
        [Fact]
        public void AutoMapperConfigurationIsValid()
        {
            Mapper.Initialize(m => m.AddProfile<AutoMapperProfileConfig>());
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void GetProductsShouldReturnAllProducts()
        {
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            ICodeRepository codeRepository = Substitute.For<ICodeRepository>();
            IInventoryCore inventoryCore = Substitute.For<IInventoryCore>();
            IMapper mapper = Substitute.For<IMapper>();

            string products = Data.ResourceManager.GetString("Products");
            IEnumerable<Product> lstProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(products);

            productRepository.GetAll().Returns(lstProducts);

            IProductCore controller = new ProductCore(productRepository, codeRepository, inventoryCore, mapper);

            var result = controller.GetAll();

            result.Should().HaveCount(4);
        }

        [Fact]
        public void GetProductShouldReturnProduct()
        {
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            ICodeRepository codeRepository = Substitute.For<ICodeRepository>();
            IInventoryCore inventoryCore = Substitute.For<IInventoryCore>();
            IMapper mapper = Substitute.For<IMapper>();

            string products = Data.ResourceManager.GetString("Products");
            IEnumerable<Product> lstProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(products);

            productRepository.Find(1).Returns(lstProducts.First(lp => lp.Id == 1));

            IProductCore controller = new ProductCore(productRepository, codeRepository, inventoryCore, mapper);

            var result = controller.Find(1);

            result.ProductId.Should().Be(1);
        }
    }
}
