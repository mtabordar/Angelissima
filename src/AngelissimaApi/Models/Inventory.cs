namespace AngelissimaApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Inventory : BaseItem
    {
        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
