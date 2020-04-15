using Microsoft.EntityFrameworkCore.Migrations;

namespace Go_Nosh.Data.Migrations
{
    public partial class CustomerFoodTruckOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9744974e-feb7-4310-9b53-3bf5df7b9b10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c28965ca-7d0a-40d2-b01d-2686f893afe8", "89158045-1d13-43cf-a36f-eb3243e031db", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28965ca-7d0a-40d2-b01d-2686f893afe8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9744974e-feb7-4310-9b53-3bf5df7b9b10", "4d2261f4-181e-439e-aa53-fc8ffee20d03", "Admin", "ADMIN" });
        }
    }
}
