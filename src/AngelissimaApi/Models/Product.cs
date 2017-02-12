namespace AngelissimaApi.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseItem
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        public float PorcentageIncrease { get; set; }

        public List<Code> Codes { get; set; }
    }
}
