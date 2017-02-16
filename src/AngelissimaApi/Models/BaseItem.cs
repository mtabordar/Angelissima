namespace AngelissimaApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseItem
    {
        [Key]
        public int Id { get; set; }

        public DateTime UpdatedAt
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
