using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class removedWorkDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43bb9c4e-02d2-47bd-a47e-6918745362ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808f6e22-a494-41bd-92db-6404968329b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8d2340c-0bc1-4d1a-9728-742a44e3abc6", "d7f0aa2c-5f7e-4be6-9608-94134581e77b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2902583-8053-4e38-9d23-9f2a6ef4d27e", "41ac26b3-6d03-4d8a-b569-a7e2392a065b", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2902583-8053-4e38-9d23-9f2a6ef4d27e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d2340c-0bc1-4d1a-9728-742a44e3abc6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43bb9c4e-02d2-47bd-a47e-6918745362ba", "12956abd-1114-48d7-b934-1f26e5e9677a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "808f6e22-a494-41bd-92db-6404968329b4", "465c7612-4ae4-4cc7-b801-239f508f7104", "Employee", "EMPLOYEE" });
        }
    }
}
