using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonShop.SalesService.Migrations
{
    public partial class AddOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Customer = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingAddress = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Customer", "Date", "OrderStatus", "ShippingAddress", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("e148921a-f292-4078-8004-120a392836ab"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), 80m },
                    { new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), 90m },
                    { new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 14, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), 110m },
                    { new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), 230m }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"),
                column: "OrderId",
                value: new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"),
                column: "OrderId",
                value: new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"),
                column: "OrderId",
                value: new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"),
                column: "OrderId",
                value: new Guid("e148921a-f292-4078-8004-120a392836ab"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"),
                column: "OrderId",
                value: new Guid("e148921a-f292-4078-8004-120a392836ab"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"),
                column: "OrderId",
                value: new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"),
                column: "OrderId",
                value: new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"),
                column: "OrderId",
                value: new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de039434-d200-43b9-8191-79869c895821"),
                column: "OrderId",
                value: new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"),
                column: "OrderId",
                value: new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");
        }
    }
}
