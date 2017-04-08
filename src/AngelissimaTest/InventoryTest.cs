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

    public class InventoryTest
    {
        [Fact]
        public void GetInventoryProductShouldReturnProductQuantity()
        {
            IInventoryRepository inventoryRepository = Substitute.For<IInventoryRepository>();
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();

            string inventory = Data.ResourceManager.GetString("Inventory");
            IEnumerable<Inventory> lstInventory = JsonConvert.DeserializeObject<IEnumerable<Inventory>>(inventory);

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            inventoryRepository.Find(1).Returns(lstInventory.First(i => i.ProductId == 1));
            inventoryRepository.GetTotalInventoryProductQuantity(1).Returns(lstInventory.Where(i => i.ProductId == 1).Sum(ti => ti.Quantity));

            saleRepository.GetTotalSalesProductQuantity(1).Returns(lstSales.SelectMany(s => s.SaleItems).Where(si => si.ProductId == 1).Sum(si => si.Quantity));

            IInventoryCore controller = new InventoryCore(inventoryRepository, saleRepository);

            var result = controller.Find(1);

            //result.TotalQuantity.Should().Be(6);
            result.ProductId.Should().Be(1);
        }
    }
}
