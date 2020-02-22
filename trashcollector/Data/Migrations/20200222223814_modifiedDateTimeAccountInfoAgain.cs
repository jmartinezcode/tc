using Microsoft.EntityFrameworkCore.Migrations;

namespace trashcollector.Data.Migrations
{
    public partial class modifiedDateTimeAccountInfoAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6f774f-1de9-4bcf-855d-489209391b25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4376bb1-1aec-4510-a4b8-886d7717e8df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de3b7f52-ba06-424f-ae6b-ebd68dcc4af6", "c8995b05-2af1-45cb-8a0f-5483eb5865d0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92397d9b-ba42-47bf-8f86-e99c7607890d", "9f2bdbcb-3f5f-40ed-bf0b-defc22abf17d", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92397d9b-ba42-47bf-8f86-e99c7607890d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de3b7f52-ba06-424f-ae6b-ebd68dcc4af6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b6f774f-1de9-4bcf-855d-489209391b25", "bd09ae85-3ac2-4a37-a284-75f4dafb8300", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4376bb1-1aec-4510-a4b8-886d7717e8df", "12828467-e59b-4af2-9c64-e77fe83d9a6d", "Employee", "EMPLOYEE" });
        }
    }
}
