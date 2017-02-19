namespace AngelissimaApi.Models
{
    public class Code
    {
        public string BarCode { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}