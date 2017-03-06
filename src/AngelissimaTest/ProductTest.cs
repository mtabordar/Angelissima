namespace AngelissimaTest
{
    using AngelissimaApi;
    using AngelissimaApi.Controllers;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using AngelissimaApi.ViewModels;
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using NSubstitute;
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;

    public class ProductTest
    {
        IMapper mapper;
        public ProductTest()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfileConfig>();
            });

            mapper = config.CreateMapper();
        }

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
            ILogger<ProductController> logger = Substitute.For<ILogger<ProductController>>();

            string products = Data.ResourceManager.GetString("Products");
            IEnumerable<Product> lstProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(products);

            productRepository.GetAll().Returns(lstProducts);

            ProductController controller = new ProductController(productRepository, mapper, logger);

            var result = controller.Get();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(viewResult.Value);

            model.Should().HaveCount(4);
        }

        [Fact]
        public void GetProductShouldReturnProduct()
        {
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            ILogger<ProductController> logger = Substitute.For<ILogger<ProductController>>();

            string products = Data.ResourceManager.GetString("Products");
            IEnumerable<Product> lstProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(products);

            productRepository.Find(1).Returns(lstProducts.First(lp => lp.Id == 1));

            ProductController controller = new ProductController(productRepository, mapper, logger);

            var result = controller.Get(1);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(viewResult.Value);

            model.ProductId.Should().Be(1);
        }
    }
}
