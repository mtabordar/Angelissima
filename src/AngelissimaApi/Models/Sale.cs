namespace AngelissimaApi.Models
{
    using System;
    using System.Collections.Generic;

    public class Sale : BaseItem
    {
        public DateTime SaleDate { get; set; }
        public int TotalPrice { get; set; }

        public List<SaleItem> SaleItems { get; set; }
    }
}
