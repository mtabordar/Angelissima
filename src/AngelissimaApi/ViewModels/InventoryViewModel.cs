namespace AngelissimaApi.ViewModels
{
    using System;

    public class InventoryViewModel
    {
        public DateTime RegistrationDate { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
