using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasics.Migrations
{
    public partial class Added1tomanyrelationshipCountryCitiesandCityPeopleandaddedCityPersoncitytoperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "PersonCityId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CitiesId",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonCityId",
                table: "People",
                column: "PersonCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_PersonCityId",
                table: "People",
                column: "PersonCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_PersonCityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonCityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonCityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CitiesId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
