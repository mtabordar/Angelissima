namespace AngelissimaApi.Models
{
    public class BarCode
    {
        public string Code { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}