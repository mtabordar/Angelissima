using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AngelissimaApi.Models;

namespace AngelissimaApi.Migrations
{
    [DbContext(typeof(AngelContext))]
    [Migration("20170306021811_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("AngelissimaApi.Models.Code", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productid");

                    b.Property<string>("BarCode")
                        .HasColumnName("barcode");

                    b.HasKey("ProductId", "BarCode");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("code");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ProductId")
                        .HasColumnName("productid");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnName("registrationdate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("inventory");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int>("MinimunQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("minimunquantity")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<decimal>("SalePrice")
                        .HasColumnName("saleprice");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("unitprice");

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnName("saledate");

                    b.Property<int>("TotalPrice")
                        .HasColumnName("totalprice");

                    b.HasKey("Id");

                    b.ToTable("sale");
                });

            modelBuilder.Entity("AngelissimaApi.Models.SaleItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productid");

                    b.Property<int>("SaleId")
                        .HasColumnName("saleid");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<decimal>("price")
                        .HasColumnName("price");

                    b.HasKey("ProductId", "SaleId");

                    b.HasIndex("SaleId");

                    b.ToTable("saleitem");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Code", b =>
                {
                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithOne("BarCodes")
                        .HasForeignKey("AngelissimaApi.Models.Code", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngelissimaApi.Models.Inventory", b =>
                {
                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngelissimaApi.Models.SaleItem", b =>
                {
                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AngelissimaApi.Models.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
