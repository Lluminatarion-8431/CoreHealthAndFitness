using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_Health_and_Fitness.Data.Migrations
{
    public partial class CHAF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bd0f36c-9315-4d63-9a40-84e4f1e14c40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c613a272-00c4-40bd-866a-7988b48d4e36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f03465d9-1818-44f4-a441-db9092426212", "75b30eee-ee74-4206-a8ed-2b45f8cc2e45", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1289e619-f784-4eee-9ffa-6c82d5820b06", "1925a772-c508-4c1f-beda-fda09a86af21", "PersonalTrainer", "PERSONALTRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1289e619-f784-4eee-9ffa-6c82d5820b06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f03465d9-1818-44f4-a441-db9092426212");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bd0f36c-9315-4d63-9a40-84e4f1e14c40", "8bffcb3d-1f28-42f2-ae7c-80bbed5f1b0a", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c613a272-00c4-40bd-866a-7988b48d4e36", "1ecbdb0d-6744-4d4c-9155-2fed8e9d3f98", "PersonalTrainer", "PERSONALTRAINER" });
        }
    }
}
