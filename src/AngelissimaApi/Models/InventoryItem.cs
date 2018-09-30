namespace AngelissimaApi.Models
{
    using System;

    public class InventoryItem : BaseItem
    {
        public DateTime RegistrationDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int InventoryItemStatusId { get; set; }
        public InventoryItemStatus InventoryItemStatus { get; set; }
    }
}
