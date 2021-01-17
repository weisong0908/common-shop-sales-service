using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonShop.SalesService.Migrations
{
    public partial class SeedCustomerAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("6865a7fa-6866-4516-9002-53cc8386991e"), "weisong0908@gmail.com", "John 0", "98765432" },
                    { new Guid("f5f1e765-a3bb-44bb-89b9-52ab8eab9db4"), "weisong0908@gmail.com", "John 1", "98765432" },
                    { new Guid("3a538afc-1441-4c96-bf86-81a18ad0ca04"), "weisong0908@gmail.com", "John 2", "98765432" },
                    { new Guid("97bdd552-ae59-403a-ba6c-3162d17560ec"), "weisong0908@gmail.com", "John 3", "98765432" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Line1", "Line2", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("108e7c96-ea21-44f2-9cbe-db4237c2d1dd"), new Guid("6865a7fa-6866-4516-9002-53cc8386991e"), "Block 0 Street 0", "#10-0", "123456" },
                    { new Guid("41881c20-df28-43df-8e1c-e42748181ea3"), new Guid("f5f1e765-a3bb-44bb-89b9-52ab8eab9db4"), "Block 1 Street 2", "#9-1", "123456" },
                    { new Guid("5df7c00b-3cfd-48e7-a674-6aee0f120313"), new Guid("3a538afc-1441-4c96-bf86-81a18ad0ca04"), "Block 2 Street 4", "#8-4", "123456" },
                    { new Guid("c9871377-210e-4979-a006-a8e156b05147"), new Guid("97bdd552-ae59-403a-ba6c-3162d17560ec"), "Block 3 Street 6", "#7-9", "123456" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("108e7c96-ea21-44f2-9cbe-db4237c2d1dd"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("41881c20-df28-43df-8e1c-e42748181ea3"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5df7c00b-3cfd-48e7-a674-6aee0f120313"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c9871377-210e-4979-a006-a8e156b05147"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3a538afc-1441-4c96-bf86-81a18ad0ca04"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6865a7fa-6866-4516-9002-53cc8386991e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("97bdd552-ae59-403a-ba6c-3162d17560ec"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f5f1e765-a3bb-44bb-89b9-52ab8eab9db4"));
        }
    }
}
