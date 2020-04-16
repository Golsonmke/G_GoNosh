using Microsoft.EntityFrameworkCore.Migrations;

namespace Go_Nosh.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35c164c6-13e8-439b-a6af-71f62033fc57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a7f9819-8e4f-4496-b31e-7639495f0c0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71a161e5-a186-4353-9870-c5eb82aec01f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68898c87-0cc3-4112-835c-bdc4648d1a7d", "35c96e5a-8614-4c3e-8446-2c92ffc19178", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1109f64c-9c8e-4847-a3c6-00347d88bb0f", "c4a60ca3-5c80-4cb4-8ac0-4d8cb217460a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f4b1b4a-2d43-452a-b975-b438d6f97ab0", "1c0f37f5-31d4-4ba2-a763-bec1b5e70c08", "Owner", "OWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1109f64c-9c8e-4847-a3c6-00347d88bb0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68898c87-0cc3-4112-835c-bdc4648d1a7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f4b1b4a-2d43-452a-b975-b438d6f97ab0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a7f9819-8e4f-4496-b31e-7639495f0c0f", "f0e8a87b-8cb1-4ecf-85e4-e717b199bf5d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71a161e5-a186-4353-9870-c5eb82aec01f", "1d55176e-51dc-495b-995e-f258eb79e2f0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35c164c6-13e8-439b-a6af-71f62033fc57", "1e912fa4-61ed-4c5e-894a-0b5e4e7098ae", "Owner", "OWNER" });
        }
    }
}
