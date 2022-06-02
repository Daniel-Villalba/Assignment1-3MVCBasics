using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasics.Migrations
{
    public partial class Seededsomemoredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "PersonCityId", "PhoneNumber" },
                values: new object[,]
                {
                    { -1, null, "Adam Andersson", 1, "+4631445511" },
                    { -2, null, "Bengt Bengtsson", 1, "+4631548422" },
                    { -3, null, "Cesar Cederquist", 4, "+4731443433" },
                    { -4, null, "David Dalquist", 5, "+47314434242" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "PersonCityId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "Adam Andersson", 1, "+4631445511" },
                    { 2, null, "Bengt Bengtsson", 1, "+4631548422" },
                    { 3, null, "Cesar Cederquist", 4, "+4731443433" },
                    { 4, null, "David Dalquist", 5, "+47314434242" }
                });
        }
    }
}
