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

    public class SaleTest
    {
        IMapper mapper;
        public SaleTest()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfileConfig>();
            });

            mapper = config.CreateMapper();
        }

        [Fact]
        public void GetSalesShouldReturnSalesQuantity()
        {
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();
            ILogger<SaleController> logger = Substitute.For<ILogger<SaleController>>();

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            saleRepository.GetAll().Returns(lstSales);

            SaleController controller = new SaleController(saleRepository, mapper, logger);

            var result = controller.Get();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<SaleViewModel>>(viewResult.Value);

            model.Should().HaveCount(6);            
        }

        [Fact]
        public void GetSalesShouldReturnSalesItemQuantity()
        {
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();
            ILogger<SaleController> logger = Substitute.For<ILogger<SaleController>>();

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            saleRepository.Find(1).Returns(lstSales.First(s => s.Id == 1));

            SaleController controller = new SaleController(saleRepository, mapper, logger);

            var result = controller.Get(1);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<SaleViewModel>(viewResult.Value);

            model.SaleItems.Should().HaveCount(2);
        }
    }
}
