namespace AngelissimaApi.Models
{
    public class Code : BaseItem
    {
        public double BarCode { get; set; }

        public int productId { get; set; }
        public Product product { get; set; }
    }
}