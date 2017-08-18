namespace AngelissimaApi.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        public int MinimunQuantity { get; set; }

        public BarCodeViewModel BarCodes { get; set; }

        public int AvailableQuantity { get; set; }
    }

    public class BarCodeViewModel
    {
        public string BarCode { get; set; }
    }
}
