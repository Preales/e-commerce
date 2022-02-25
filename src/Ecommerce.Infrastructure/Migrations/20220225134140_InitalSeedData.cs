using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infrastructure.Migrations
{
    public partial class InitalSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CreationDate", "Deleted", "Email", "LastName", "ModificationDate", "Name", "Telephone" },
                values: new object[,]
                {
                    { "1234561", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "client_1@contoso.com", "LastName 1", null, "Client 1", "1234561" },
                    { "1234562", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "client_2@contoso.com", "LastName 2", null, "Client 2", "1234562" },
                    { "1234563", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "client_3@contoso.com", "LastName 3", null, "Client 3", "1234563" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "ModificationDate", "Price", "Tax" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product 1", null, 3953m, 1 },
                    { 2, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product 2", null, 5466m, 19 },
                    { 3, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product 3", null, 5379m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "Address", "City", "ClientId", "Country", "CreationDate", "Deleted", "Department", "ModificationDate" },
                values: new object[] { new Guid("b7fc1742-3c68-4630-a2f6-a1f7c0007a2f"), "Address 1", "City 1", "1234561", "CO", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Department 1", null });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "Address", "City", "ClientId", "Country", "CreationDate", "Deleted", "Department", "ModificationDate" },
                values: new object[] { new Guid("a8f1c52f-39d1-4b59-858b-8744b01796fb"), "Address 2", "City 2", "1234562", "CO", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Department 2", null });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "Address", "City", "ClientId", "Country", "CreationDate", "Deleted", "Department", "ModificationDate" },
                values: new object[] { new Guid("98c04cea-5188-44d6-8ce6-db72fe4d1b7e"), "Address 3", "City 3", "1234563", "CO", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Department 3", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shipping",
                keyColumn: "Id",
                keyValue: new Guid("98c04cea-5188-44d6-8ce6-db72fe4d1b7e"));

            migrationBuilder.DeleteData(
                table: "Shipping",
                keyColumn: "Id",
                keyValue: new Guid("a8f1c52f-39d1-4b59-858b-8744b01796fb"));

            migrationBuilder.DeleteData(
                table: "Shipping",
                keyColumn: "Id",
                keyValue: new Guid("b7fc1742-3c68-4630-a2f6-a1f7c0007a2f"));

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: "1234561");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: "1234562");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: "1234563");
        }
    }
}
