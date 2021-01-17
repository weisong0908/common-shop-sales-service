using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonShop.SalesService.Migrations
{
    public partial class SeedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date", "OrderStatus", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("e148921a-f292-4078-8004-120a392836ab"), new Guid("6865a7fa-6866-4516-9002-53cc8386991e"), new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Local), 0, 22m },
                    { new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"), new Guid("f5f1e765-a3bb-44bb-89b9-52ab8eab9db4"), new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), 0, 42m },
                    { new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"), new Guid("3a538afc-1441-4c96-bf86-81a18ad0ca04"), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, 62m },
                    { new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"), new Guid("97bdd552-ae59-403a-ba6c-3162d17560ec"), new DateTime(2021, 1, 14, 0, 0, 0, 0, DateTimeKind.Local), 0, 82m }
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "Cost", "OrderId", "Title" },
                values: new object[,]
                {
                    { new Guid("132898f9-ef64-474b-884c-d0b7801e9269"), 2m, new Guid("e148921a-f292-4078-8004-120a392836ab"), "Shipping fee" },
                    { new Guid("48173c46-4ad1-4f94-8241-2c2aadd9cd49"), 2m, new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"), "Shipping fee" },
                    { new Guid("d7b7454d-0593-48de-aab2-d20a00b3db96"), 2m, new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"), "Shipping fee" },
                    { new Guid("02238e28-1b03-48db-94b9-c0b335ae6d7a"), 2m, new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"), "Shipping fee" }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderId", "ProductId", "Amount", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e148921a-f292-4078-8004-120a392836ab"), new Guid("de039434-d200-43b9-8191-79869c895821"), 20m, 2 },
                    { new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"), new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"), 40m, 2 },
                    { new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"), new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"), 60m, 2 },
                    { new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"), new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"), 80m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("02238e28-1b03-48db-94b9-c0b335ae6d7a"));

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("132898f9-ef64-474b-884c-d0b7801e9269"));

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("48173c46-4ad1-4f94-8241-2c2aadd9cd49"));

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("d7b7454d-0593-48de-aab2-d20a00b3db96"));

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"), new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78") });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"), new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455") });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"), new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40") });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("e148921a-f292-4078-8004-120a392836ab"), new Guid("de039434-d200-43b9-8191-79869c895821") });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e148921a-f292-4078-8004-120a392836ab"));
        }
    }
}
