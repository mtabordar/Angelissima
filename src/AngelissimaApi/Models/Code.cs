using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngelissimaApi.Models
{
    public class Code
    {
        [Key, Column(Order =1)]
        public string BarCode { get; set; }

        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}