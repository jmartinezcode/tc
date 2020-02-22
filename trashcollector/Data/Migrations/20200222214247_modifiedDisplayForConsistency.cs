using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class modifiedDisplayForConsistency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a16d0ad4-fd06-4797-8659-8237a34b72a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7ba340c-6bbd-41d7-8fff-7f30caef6eea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e8cbdcc-a908-428d-aa0f-347291ef4860", "7e1e420b-91fb-49c6-af4a-2f72955e56c2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1409c0b-8b3f-4746-9d19-c8bf24f653f9", "bace3fb2-d448-4686-88dc-81a5c687b187", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8cbdcc-a908-428d-aa0f-347291ef4860");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1409c0b-8b3f-4746-9d19-c8bf24f653f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a16d0ad4-fd06-4797-8659-8237a34b72a5", "7327c9cd-87b0-427c-b631-8e95e59de303", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7ba340c-6bbd-41d7-8fff-7f30caef6eea", "a561e59f-3f61-414d-932a-93d5b2cdc6dc", "Employee", "EMPLOYEE" });
        }
    }
}
