using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_Health_and_Fitness.Migrations
{
    public partial class CHAF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57eb06f7-560a-4f7d-b61c-ce493b568b8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "936a1860-8e93-4cfd-b065-6feaf820612d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e18f262f-66d9-4fca-943e-f9b72277b5f2", "2b189a47-f0d3-41c2-b5fa-c2c44c805e73", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7e88341-ad31-4621-8ed8-3deaac55b8cc", "04dc00be-c1e7-41b1-a0d9-05ffcce2da27", "PersonalTrainer", "PERSONALTRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e18f262f-66d9-4fca-943e-f9b72277b5f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e88341-ad31-4621-8ed8-3deaac55b8cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "936a1860-8e93-4cfd-b065-6feaf820612d", "56b1941c-9914-4cdb-8729-8170569a2524", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57eb06f7-560a-4f7d-b61c-ce493b568b8f", "0a1567c5-ec95-4c88-947b-3b01ad94dec5", "PersonalTrainer", "PERSONALTRAINER" });
        }
    }
}
