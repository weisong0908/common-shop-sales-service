using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonShop.SalesService.Migrations
{
    public partial class AddProductCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoryId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"),
                column: "Date",
                value: new DateTime(2021, 1, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"),
                column: "Date",
                value: new DateTime(2021, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"),
                column: "Date",
                value: new DateTime(2021, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e148921a-f292-4078-8004-120a392836ab"),
                column: "Date",
                value: new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("6280198e-df28-4fa7-a095-3671f51501c7"), "Category 1" },
                    { new Guid("b1d36dfd-4c8a-48d1-8f61-af926ddfdf41"), "Category 2" },
                    { new Guid("10fc51a4-1f9d-4296-ae45-4b797d466fae"), "Category 3" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"),
                column: "ProductCategoryId",
                value: new Guid("6280198e-df28-4fa7-a095-3671f51501c7"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"),
                column: "ProductCategoryId",
                value: new Guid("6280198e-df28-4fa7-a095-3671f51501c7"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"),
                column: "ProductCategoryId",
                value: new Guid("b1d36dfd-4c8a-48d1-8f61-af926ddfdf41"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"),
                column: "ProductCategoryId",
                value: new Guid("b1d36dfd-4c8a-48d1-8f61-af926ddfdf41"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"),
                column: "ProductCategoryId",
                value: new Guid("b1d36dfd-4c8a-48d1-8f61-af926ddfdf41"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"),
                column: "ProductCategoryId",
                value: new Guid("6280198e-df28-4fa7-a095-3671f51501c7"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"),
                column: "ProductCategoryId",
                value: new Guid("6280198e-df28-4fa7-a095-3671f51501c7"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"),
                column: "ProductCategoryId",
                value: new Guid("b1d36dfd-4c8a-48d1-8f61-af926ddfdf41"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de039434-d200-43b9-8191-79869c895821"),
                column: "ProductCategoryId",
                value: new Guid("6280198e-df28-4fa7-a095-3671f51501c7"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"),
                column: "ProductCategoryId",
                value: new Guid("b1d36dfd-4c8a-48d1-8f61-af926ddfdf41"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c"),
                column: "Date",
                value: new DateTime(2021, 1, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"),
                column: "Date",
                value: new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"),
                column: "Date",
                value: new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e148921a-f292-4078-8004-120a392836ab"),
                column: "Date",
                value: new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"),
                column: "Category",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"),
                column: "Category",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"),
                column: "Category",
                value: "Category 2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"),
                column: "Category",
                value: "Category 2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"),
                column: "Category",
                value: "Category 2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"),
                column: "Category",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"),
                column: "Category",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"),
                column: "Category",
                value: "Category 2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de039434-d200-43b9-8191-79869c895821"),
                column: "Category",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"),
                column: "Category",
                value: "Category 2");
        }
    }
}
