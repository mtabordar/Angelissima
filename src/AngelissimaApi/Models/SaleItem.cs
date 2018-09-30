namespace AngelissimaApi.Models
{
    public class SaleItem
    {
        public decimal Price { get; set; }

        public int InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
