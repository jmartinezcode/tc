using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class addedLastPickupDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2902583-8053-4e38-9d23-9f2a6ef4d27e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d2340c-0bc1-4d1a-9728-742a44e3abc6");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPickupDate",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a16d0ad4-fd06-4797-8659-8237a34b72a5", "7327c9cd-87b0-427c-b631-8e95e59de303", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7ba340c-6bbd-41d7-8fff-7f30caef6eea", "a561e59f-3f61-414d-932a-93d5b2cdc6dc", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a16d0ad4-fd06-4797-8659-8237a34b72a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7ba340c-6bbd-41d7-8fff-7f30caef6eea");

            migrationBuilder.DropColumn(
                name: "LastPickupDate",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8d2340c-0bc1-4d1a-9728-742a44e3abc6", "d7f0aa2c-5f7e-4be6-9608-94134581e77b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2902583-8053-4e38-9d23-9f2a6ef4d27e", "41ac26b3-6d03-4d8a-b569-a7e2392a065b", "Employee", "EMPLOYEE" });
        }
    }
}
