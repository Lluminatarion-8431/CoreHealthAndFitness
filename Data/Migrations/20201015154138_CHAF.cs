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
                keyValue: "1289e619-f784-4eee-9ffa-6c82d5820b06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f03465d9-1818-44f4-a441-db9092426212");

            migrationBuilder.RenameColumn(
                name: "zipCode",
                table: "Clients",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "streetAddress",
                table: "Clients",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Clients",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Clients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Clients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Clients",
                newName: "City");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fb9c4f3-3fec-4153-b354-bf1ad3e109c8", "6b8d6257-5075-4f2c-bc19-9c3a9281008f", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1684aea-3055-4317-b8b9-caa05739bfc3", "382e6913-af83-40b4-8387-dcd3ccd99dfb", "PersonalTrainer", "PERSONALTRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fb9c4f3-3fec-4153-b354-bf1ad3e109c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1684aea-3055-4317-b8b9-caa05739bfc3");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Clients",
                newName: "zipCode");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Clients",
                newName: "streetAddress");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Clients",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Clients",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Clients",
                newName: "city");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f03465d9-1818-44f4-a441-db9092426212", "75b30eee-ee74-4206-a8ed-2b45f8cc2e45", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1289e619-f784-4eee-9ffa-6c82d5820b06", "1925a772-c508-4c1f-beda-fda09a86af21", "PersonalTrainer", "PERSONALTRAINER" });
        }
    }
}
