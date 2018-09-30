﻿// <auto-generated />
using System;
using AngelissimaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AngelissimaApi.Migrations
{
    [DbContext(typeof(AngelContext))]
    partial class AngelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AngelissimaApi.Models.BarCode", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productid");

                    b.Property<string>("Code")
                        .HasColumnName("code");

                    b.HasKey("ProductId", "Code");

                    b.ToTable("barcode");
                });

            modelBuilder.Entity("AngelissimaApi.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("InventoryItemStatusId");

                    b.Property<int>("ProductId")
                        .HasColumnName("productid");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnName("registrationdate");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemStatusId");

                    b.HasIndex("ProductId");

                    b.ToTable("inventoryitem");
                });

            modelBuilder.Entity("AngelissimaApi.Models.InventoryItemStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("inventoryitemstatus");

                    b.HasData(
                        new { Id = 1, Description = "Available", Name = "Available" },
                        new { Id = 2, Description = "Sold", Name = "Sold" },
                        new { Id = 3, Description = "Defective", Name = "Defective" },
                        new { Id = 4, Description = "NonExistent", Name = "NonExistent" }
                    );
                });

            modelBuilder.Entity("AngelissimaApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<int>("RecommendedQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("minimunquantity")
                        .HasDefaultValue(0);

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
                    b.Property<int>("InventoryItemId")
                        .HasColumnName("inventoryitemid");

                    b.Property<int>("SaleId")
                        .HasColumnName("saleid");

                    b.Property<decimal>("Price")
                        .HasColumnName("price");

                    b.HasKey("InventoryItemId", "SaleId");

                    b.HasIndex("SaleId");

                    b.ToTable("saleitem");
                });

            modelBuilder.Entity("AngelissimaApi.Models.BarCode", b =>
                {
                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithMany("BarCodes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngelissimaApi.Models.InventoryItem", b =>
                {
                    b.HasOne("AngelissimaApi.Models.InventoryItemStatus", "InventoryItemStatus")
                        .WithMany()
                        .HasForeignKey("InventoryItemStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngelissimaApi.Models.SaleItem", b =>
                {
                    b.HasOne("AngelissimaApi.Models.InventoryItem", "InventoryItem")
                        .WithMany()
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AngelissimaApi.Models.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
