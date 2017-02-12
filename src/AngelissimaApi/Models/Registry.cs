namespace AngelissimaApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Registry : BaseItem
    {
        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
