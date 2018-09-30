namespace AngelissimaApi.ViewModels
{
    using System;

    public class InventoryItemViewModel
    {
        public DateTime RegistrationDate { get; set; }

        public int AvailableQuantity { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
