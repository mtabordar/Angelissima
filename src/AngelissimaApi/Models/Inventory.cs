﻿namespace AngelissimaApi.Models
{
    using System;

    public class Inventory : BaseItem
    {
        public DateTime RegistrationDate { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
