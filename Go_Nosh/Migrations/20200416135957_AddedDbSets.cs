using Microsoft.EntityFrameworkCore.Migrations;

namespace Go_Nosh.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FoodTrucks",
                columns: table => new
                {
                    FoodTruckPrimaryKey = table.Column<string>(nullable: false),
                    FoodTruckName = table.Column<string>(nullable: true),
                    FoodTruckPhone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PriceRangeIndex = table.Column<int>(nullable: false),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Open_now = table.Column<bool>(nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    Lng = table.Column<float>(nullable: false),
                    FoodType = table.Column<string>(nullable: true),
                    Price_level = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Place_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTrucks", x => x.FoodTruckPrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerPrimary = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    FoodTruckPrimarayKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerPrimary);
                    table.ForeignKey(
                        name: "FK_Owners_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "661a7ff0-908f-4758-9dbd-dc028f616678", "45cab6e1-f87d-4c22-8fb7-6d1a933b8b45", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bcc3d454-9a3d-4edd-aaa5-b1b845db4e40", "0dc53339-7f30-4d60-9b82-0b4f8450262d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab8628af-5e51-48a9-94ee-f1eed087a25d", "03b3c4f4-a64e-410a-8d72-28b6272f80bb", "Owner", "OWNER" });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_IdentityUserId",
                table: "Owners",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodTrucks");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661a7ff0-908f-4758-9dbd-dc028f616678");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab8628af-5e51-48a9-94ee-f1eed087a25d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcc3d454-9a3d-4edd-aaa5-b1b845db4e40");

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
    }
}
