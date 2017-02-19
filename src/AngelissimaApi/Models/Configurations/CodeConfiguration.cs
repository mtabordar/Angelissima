namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CodeConfiguration
    {
        public static void ConfigureCodeEntity(EntityTypeBuilder<Code> entityBuilder)
        {
            entityBuilder.ToTable("Code").HasKey(c => new { c.ProductId, c.BarCode });                
        }
    }
}
