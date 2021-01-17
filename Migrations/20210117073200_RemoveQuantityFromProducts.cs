using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonShop.SalesService.Migrations
{
    public partial class RemoveQuantityFromProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"),
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"),
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"),
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"),
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"),
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"),
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"),
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"),
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de039434-d200-43b9-8191-79869c895821"),
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"),
                column: "Quantity",
                value: 1);
        }
    }
}
