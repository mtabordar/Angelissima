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

    public class InventoryTest
    {
        IMapper mapper;
        public InventoryTest()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfileConfig>();
            });

            mapper = config.CreateMapper();
        }

        [Fact]
        public void GetInventoryProductShouldReturnProductQuantity()
        {
            IInventoryRepository inventoryRepository = Substitute.For<IInventoryRepository>();
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();
            ILogger<InventoryController> logger = Substitute.For<ILogger<InventoryController>>();

            string inventory = Data.ResourceManager.GetString("Inventory");
            IEnumerable<Inventory> lstInventory = JsonConvert.DeserializeObject<IEnumerable<Inventory>>(inventory);

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            inventoryRepository.Find(1).Returns(lstInventory.First(i => i.ProductId == 1));
            inventoryRepository.GetTotalInventoryProductQuantity(1).Returns(lstInventory.Where(i => i.ProductId == 1).Sum(ti => ti.Quantity));

            saleRepository.GetTotalSalesProductQuantity(1).Returns(lstSales.SelectMany(s => s.SaleItems).Where(si => si.ProductId == 1).Sum(si => si.Quantity));

            InventoryController controller = new InventoryController(inventoryRepository, saleRepository, mapper, logger);

            var result = controller.Get(1);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<InventoryViewModel>(viewResult.Value);

            model.TotalQuantity.Should().Be(6);
            model.ProductId.Should().Be(1);
        }
    }
}
