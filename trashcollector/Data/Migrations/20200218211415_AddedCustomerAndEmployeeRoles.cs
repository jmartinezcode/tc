using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class AddedCustomerAndEmployeeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "362078d2-c871-415d-823d-9bff0b031906");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "362078d2-c871-415d-823d-9bff0b031906", "86a1544d-7355-4f96-b06a-2e54f05bce62", "Admin", "ADMIN" });
        }
    }
}
