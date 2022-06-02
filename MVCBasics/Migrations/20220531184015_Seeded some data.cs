using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasics.Migrations
{
    public partial class Seededsomedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "People",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CitiesId", "Name" },
                values: new object[] { 1, null, "Sweden" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CitiesId", "Name" },
                values: new object[] { 2, null, "Norway" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Gothenburg" },
                    { 2, 1, "Stockholm" },
                    { 3, 1, "Malmoe" },
                    { 4, 2, "Oslo" },
                    { 5, 2, "Bergen" }
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { null, 1, "+4631445511" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { null, 1, "+4631548422" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { null, 4, "+4731443433" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { null, 5, "+47314434242" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "PersonCityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2,
                column: "PersonCityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3,
                column: "PersonCityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4,
                column: "PersonCityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { "Trollhättan", null, "031445511" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { "Göteborg", null, "031548422" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { "Stockholm", null, "031443433" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4,
                columns: new[] { "City", "PersonCityId", "PhoneNumber" },
                values: new object[] { "Göteborg", null, "0314434242" });
        }
    }
}
