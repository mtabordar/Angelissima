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

            string products = Data.ResourceManager.GetString("Products");
            IEnumerable<Product> lstProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(products);

            productRepository.GetAll().Returns(lstProducts);

            IProductCore controller = new ProductCore(productRepository, codeRepository);

            var result = controller.GetAll();

            result.Should().HaveCount(4);
        }

        [Fact]
        public void GetProductShouldReturnProduct()
        {
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            ICodeRepository codeRepository = Substitute.For<ICodeRepository>();

            string products = Data.ResourceManager.GetString("Products");
            IEnumerable<Product> lstProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(products);

            productRepository.Find(1).Returns(lstProducts.First(lp => lp.Id == 1));

            IProductCore controller = new ProductCore(productRepository, codeRepository);

            var result = controller.Find(1);

            result.Id.Should().Be(1);
        }
    }
}
