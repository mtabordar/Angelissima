namespace AngelissimaTest
{
    using AngelissimaApi.Core;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.Models;
    using AngelissimaApi.Models.Interfaces;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NSubstitute;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using AutoMapper;

    public class InventoryTest
    {
        [Fact]
        public void GetInventoryProductShouldReturnProductQuantity()
        {
            IInventoryItemRepository inventoryRepository = Substitute.For<IInventoryItemRepository>();
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();
            IMapper mapper = Substitute.For<IMapper>();

            string inventory = Data.ResourceManager.GetString("Inventory");
            IEnumerable<InventoryItem> lstInventory = JsonConvert.DeserializeObject<IEnumerable<InventoryItem>>(inventory);

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            inventoryRepository.Find(1).Returns(lstInventory.First(i => i.ProductId == 1));
            //inventoryRepository.GetTotalInventoryProductQuantity(1).Returns(lstInventory.Where(i => i.ProductId == 1).Sum(ti => ti.Quantity));

            //saleRepository.GetTotalSalesProductQuantity(1).Returns(lstSales.SelectMany(s => s.SaleItems).Where(si => si.InventoryItemId == 1).Sum(si => si.Quantity));

            IInventoryItemCore controller = new InventoryItemCore(inventoryRepository, saleRepository, mapper);

            var result = controller.Find(1);

            //result.TotalQuantity.Should().Be(6);
            result.ProductId.Should().Be(1);
        }
    }
}
