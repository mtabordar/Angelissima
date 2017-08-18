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

    public class SaleTest
    {
        [Fact]
        public void GetSalesShouldReturnSalesQuantity()
        {
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();
            IMapper mapper = Substitute.For<IMapper>();

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            saleRepository.GetAll().Returns(lstSales);

            ISaleCore controller = new SaleCore(saleRepository, mapper);

            var result = controller.GetAll();

            result.Should().HaveCount(6);
        }

        [Fact]
        public void GetSalesShouldReturnSalesItemQuantity()
        {
            ISaleRepository saleRepository = Substitute.For<ISaleRepository>();
            IMapper mapper = Substitute.For<IMapper>();

            string sales = Data.ResourceManager.GetString("Sales");
            IEnumerable<Sale> lstSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(sales);

            saleRepository.Find(1).Returns(lstSales.First(s => s.Id == 1));

            ISaleCore controller = new SaleCore(saleRepository, mapper);

            var result = controller.Find(1);

            result.SaleItems.Should().HaveCount(2);
        }
    }
}
