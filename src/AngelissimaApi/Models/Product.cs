namespace AngelissimaApi.Models
{
    public class Product : BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int MinimunQuantity { get; set; }
        public Code BarCodes { get; set; }
    }
}
