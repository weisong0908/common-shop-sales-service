using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonShop.SalesService.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Price", "Quantity", "StockLevel", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("de039434-d200-43b9-8191-79869c895821"), "Category 1", "Some description", 10m, 2, 1, "https://bulma.io/images/placeholders/640x480.png", "Product 1" },
                    { new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"), "Category 2", "Some description", 20m, 3, 2, "https://bulma.io/images/placeholders/640x480.png", "Product 2" },
                    { new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"), "Category 1", "Some description", 30m, 1, 3, "https://bulma.io/images/placeholders/640x480.png", "Product 3" },
                    { new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"), "Category 2", "Some description", 40m, 2, 4, "https://bulma.io/images/placeholders/640x480.png", "Product 4" },
                    { new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"), "Category 1", "Some description", 50m, 3, 5, "https://bulma.io/images/placeholders/640x480.png", "Product 5" },
                    { new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"), "Category 2", "Some description", 60m, 1, 6, "https://bulma.io/images/placeholders/640x480.png", "Product 6" },
                    { new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"), "Category 1", "Some description", 70m, 2, 7, "https://bulma.io/images/placeholders/640x480.png", "Product 7" },
                    { new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"), "Category 2", "Some description", 80m, 3, 8, "https://bulma.io/images/placeholders/640x480.png", "Product 8" },
                    { new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"), "Category 1", "Some description", 90m, 1, 9, "https://bulma.io/images/placeholders/640x480.png", "Product 9" },
                    { new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"), "Category 2", "Some description", 100m, 2, 10, "https://bulma.io/images/placeholders/640x480.png", "Product 10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de039434-d200-43b9-8191-79869c895821"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"));
        }
    }
}
