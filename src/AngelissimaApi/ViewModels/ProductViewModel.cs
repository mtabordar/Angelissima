namespace AngelissimaApi.ViewModels
{
    using System.Collections.Generic;
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

        public int RecommendedQuantity { get; set; }

        public List<BarCodeViewModel> BarCodes { get; set; }
    }

    public class BarCodeViewModel
    {
        public string Code { get; set; }
    }
}
