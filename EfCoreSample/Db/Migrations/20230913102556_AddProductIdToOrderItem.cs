using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreSample.Db.Migrations
{
    public partial class AddProductIdToOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "tbl_order_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tbl_product",
                keyColumn: "product_id",
                keyValue: 1,
                column: "product_updatedat",
                value: new DateTime(2023, 9, 13, 17, 25, 56, 513, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "tbl_product",
                keyColumn: "product_id",
                keyValue: 2,
                column: "product_updatedat",
                value: new DateTime(2023, 9, 13, 17, 25, 56, 513, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "tbl_product",
                keyColumn: "product_id",
                keyValue: 3,
                column: "product_updatedat",
                value: new DateTime(2023, 9, 13, 17, 25, 56, 513, DateTimeKind.Local).AddTicks(1822));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_id",
                table: "tbl_order_item");

            migrationBuilder.UpdateData(
                table: "tbl_product",
                keyColumn: "product_id",
                keyValue: 1,
                column: "product_updatedat",
                value: new DateTime(2023, 9, 12, 10, 3, 37, 685, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "tbl_product",
                keyColumn: "product_id",
                keyValue: 2,
                column: "product_updatedat",
                value: new DateTime(2023, 9, 12, 10, 3, 37, 685, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "tbl_product",
                keyColumn: "product_id",
                keyValue: 3,
                column: "product_updatedat",
                value: new DateTime(2023, 9, 12, 10, 3, 37, 685, DateTimeKind.Local).AddTicks(6809));
        }
    }
}
