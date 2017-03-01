using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AngelissimaApi.Models;

namespace AngelissimaApi.Migrations
{
    [DbContext(typeof(AngelContext))]
    partial class AngelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("AngelissimaApi.Models.Code", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<string>("BarCode");

                    b.HasKey("ProductId", "BarCode");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Code");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("MinimunQuantity")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("SalePrice");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("SaleDate");

                    b.Property<int>("TotalPrice");

                    b.HasKey("Id");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("AngelissimaApi.Models.SaleItem", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SaleId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("price");

                    b.HasKey("ProductId", "SaleId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleItem");
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
