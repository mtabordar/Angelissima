namespace AngelissimaApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Registry : BaseItem
    {
        public DateTime SaleDate { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
