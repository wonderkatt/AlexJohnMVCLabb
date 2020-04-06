using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBowlTeamManager.Migrations
{
    public partial class addUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7421e0d-fdd9-42ae-a832-1192d60d0b90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb1f1c7a-ef0a-4b5d-a385-ae6b9e2fe53d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f09d2652-0c3d-4d76-9810-59e093225fdc", "07ae6d64-4171-42e5-9e11-655a0940c54b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd133bd1-ab8b-4932-992d-84de74ba09d5", "b6ccfd61-6d06-4f1c-9a09-32a2349743e3", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "eb1f1c7a-ef0a-4b5d-a385-ae6b9e2fe53d", "9d82beef-037d-4157-99d3-f174179d0c2a", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7421e0d-fdd9-42ae-a832-1192d60d0b90", "c4a798e9-e68e-4db5-9c8e-a22bb509d0d1", "Administrator", "ADMINISTRATOR" });
        }
    }
}
