using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBowlTeamManager.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd133bd1-ab8b-4932-992d-84de74ba09d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09d2652-0c3d-4d76-9810-59e093225fdc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba8aba60-5435-405d-ad16-2aa66c508539", "e17abbd3-fd1f-43b7-acb0-711be04fabf7", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1997569-aec3-4581-88dd-b672ccc7a2a0", "440ec143-1f15-45b2-ba7a-b6d886ffb8c3", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba8aba60-5435-405d-ad16-2aa66c508539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1997569-aec3-4581-88dd-b672ccc7a2a0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f09d2652-0c3d-4d76-9810-59e093225fdc", "07ae6d64-4171-42e5-9e11-655a0940c54b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd133bd1-ab8b-4932-992d-84de74ba09d5", "b6ccfd61-6d06-4f1c-9a09-32a2349743e3", "Administrator", "ADMINISTRATOR" });
        }
    }
}
