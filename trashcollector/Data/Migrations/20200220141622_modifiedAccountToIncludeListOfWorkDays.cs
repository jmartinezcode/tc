using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class modifiedAccountToIncludeListOfWorkDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f353ddb-1c18-42fa-8c00-8894494b6434");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d550217c-914a-474d-8864-79430f4dacd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e83a90e5-eb8d-4442-a84f-619b7c0a2841");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "d550217c-914a-474d-8864-79430f4dacd0", "827426a8-8677-4c68-9709-ece326a46a50", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e83a90e5-eb8d-4442-a84f-619b7c0a2841", "69b15cf4-4ee2-4602-b57f-71103bfa6d45", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f353ddb-1c18-42fa-8c00-8894494b6434", "7aa4b365-5f0e-47d5-944f-35d752a34996", "Employee", "EMPLOYEE" });
        }
    }
}
