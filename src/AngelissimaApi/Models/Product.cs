namespace AngelissimaApi.Models
{
    using System.Collections.Generic;

    public class Product : BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int RecommendedQuantity { get; set; }
        public IEnumerable<BarCode> BarCodes { get; set; }
    }
}
