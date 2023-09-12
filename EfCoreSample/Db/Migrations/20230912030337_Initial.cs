using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EfCoreSample.Db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    product_updatedat = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_product", x => x.product_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_order_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_item_name = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    order_item_quantity = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order_item", x => x.Id);
                    table.ForeignKey(
                        name: "order_item_fk",
                        column: x => x.order_id,
                        principalTable: "tbl_order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tbl_product",
                columns: new[] { "product_id", "Description", "product_name", "product_price", "product_quantity", "product_updatedat" },
                values: new object[] { 1, null, "Product 01", 100m, 10, new DateTime(2023, 9, 12, 10, 3, 37, 685, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.InsertData(
                table: "tbl_product",
                columns: new[] { "product_id", "Description", "product_name", "product_price", "product_quantity", "product_updatedat" },
                values: new object[] { 2, null, "Product 02", 500m, 111, new DateTime(2023, 9, 12, 10, 3, 37, 685, DateTimeKind.Local).AddTicks(6808) });

            migrationBuilder.InsertData(
                table: "tbl_product",
                columns: new[] { "product_id", "Description", "product_name", "product_price", "product_quantity", "product_updatedat" },
                values: new object[] { 3, null, "Product 03", 200m, 30, new DateTime(2023, 9, 12, 10, 3, 37, 685, DateTimeKind.Local).AddTicks(6809) });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_item_order_id",
                table: "tbl_order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_product_name",
                table: "tbl_product",
                column: "product_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_order_item");

            migrationBuilder.DropTable(
                name: "tbl_product");

            migrationBuilder.DropTable(
                name: "tbl_order");
        }
    }
}
