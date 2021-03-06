﻿namespace AngelissimaApi.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class ProductConfiguration
    {
        public static void ConfigureProductEntity(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.ToTable("product").HasKey(p => p.Id);
            entityBuilder.HasMany(p => p.BarCodes);
            entityBuilder.Property(p => p.Description).HasColumnName("description");
            entityBuilder.Property(p => p.Name).HasColumnName("name").IsRequired();
            entityBuilder.Property(p => p.UnitPrice).HasColumnName("unitprice").IsRequired();
            entityBuilder.Property(p => p.SalePrice).HasColumnName("saleprice").IsRequired();
            entityBuilder.Property(p => p.RecommendedQuantity).HasColumnName("minimunquantity").HasDefaultValue(0);
        }
    }
}
