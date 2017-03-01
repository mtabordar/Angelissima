namespace AngelissimaApi.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class SaleViewModel
    {
        public DateTime SaleDate { get; set; }
        public int TotalPrice { get; set; }

        public IEnumerable<SaleItemViewModel> SaleItems { get; set; }
    }

    public class SaleItemViewModel
    {
        public int Quantity { get; set; }
        public decimal price { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
