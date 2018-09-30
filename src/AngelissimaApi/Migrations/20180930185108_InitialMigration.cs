using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AngelissimaApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventoryitemstatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryitemstatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    unitprice = table.Column<decimal>(nullable: false),
                    saleprice = table.Column<decimal>(nullable: false),
                    minimunquantity = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    saledate = table.Column<DateTime>(nullable: false),
                    totalprice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "barcode",
                columns: table => new
                {
                    code = table.Column<string>(nullable: false),
                    productid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barcode", x => new { x.productid, x.code });
                    table.ForeignKey(
                        name: "FK_barcode_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventoryitem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    registrationdate = table.Column<DateTime>(nullable: false),
                    productid = table.Column<int>(nullable: false),
                    InventoryItemStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryitem", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventoryitem_inventoryitemstatus_InventoryItemStatusId",
                        column: x => x.InventoryItemStatusId,
                        principalTable: "inventoryitemstatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventoryitem_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saleitem",
                columns: table => new
                {
                    price = table.Column<decimal>(nullable: false),
                    inventoryitemid = table.Column<int>(nullable: false),
                    saleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleitem", x => new { x.inventoryitemid, x.saleid });
                    table.ForeignKey(
                        name: "FK_saleitem_inventoryitem_inventoryitemid",
                        column: x => x.inventoryitemid,
                        principalTable: "inventoryitem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saleitem_sale_saleid",
                        column: x => x.saleid,
                        principalTable: "sale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "inventoryitemstatus",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Available", "Available" },
                    { 2, "Sold", "Sold" },
                    { 3, "Defective", "Defective" },
                    { 4, "NonExistent", "NonExistent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventoryitem_InventoryItemStatusId",
                table: "inventoryitem",
                column: "InventoryItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_inventoryitem_productid",
                table: "inventoryitem",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_saleitem_saleid",
                table: "saleitem",
                column: "saleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barcode");

            migrationBuilder.DropTable(
                name: "saleitem");

            migrationBuilder.DropTable(
                name: "inventoryitem");

            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.DropTable(
                name: "inventoryitemstatus");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
