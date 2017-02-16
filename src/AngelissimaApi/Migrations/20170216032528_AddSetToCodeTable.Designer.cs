using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AngelissimaApi.Models;

namespace AngelissimaApi.Migrations
{
    [DbContext(typeof(AngelContext))]
    [Migration("20170216032528_AddSetToCodeTable")]
    partial class AddSetToCodeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("AngelissimaApi.Models.Code", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<string>("BarCode");

                    b.HasKey("ProductId", "BarCode");

                    b.HasAlternateKey("BarCode");


                    b.HasAlternateKey("BarCode", "ProductId");

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

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("SalePrice");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Registry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("SaleDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Registry");
                });

            modelBuilder.Entity("AngelissimaApi.Models.Code", b =>
                {
                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithOne("BarCode")
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

            modelBuilder.Entity("AngelissimaApi.Models.Registry", b =>
                {
                    b.HasOne("AngelissimaApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
