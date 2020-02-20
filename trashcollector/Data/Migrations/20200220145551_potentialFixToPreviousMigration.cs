using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class potentialFixToPreviousMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "231c29d0-a917-4c9c-bc2b-db7eae62c913");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39702bc7-86b6-4484-8504-99cc28025b2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf65c6db-9267-4454-9748-6928834e712a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43bb9c4e-02d2-47bd-a47e-6918745362ba", "12956abd-1114-48d7-b934-1f26e5e9677a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "808f6e22-a494-41bd-92db-6404968329b4", "465c7612-4ae4-4cc7-b801-239f508f7104", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "39702bc7-86b6-4484-8504-99cc28025b2f", "63202b9c-c456-417c-8db5-6739d96847c0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "231c29d0-a917-4c9c-bc2b-db7eae62c913", "1f7dac78-dac8-41ac-87a5-7338211f6012", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf65c6db-9267-4454-9748-6928834e712a", "aa045347-45cb-4fee-a9c2-53c7d73dfff3", "Employee", "EMPLOYEE" });
        }
    }
}
