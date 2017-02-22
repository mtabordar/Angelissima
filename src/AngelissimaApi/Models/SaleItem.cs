namespace AngelissimaApi.Models
{
    public class SaleItem
    {
        public int Quantity { get; set; }
        public decimal price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
