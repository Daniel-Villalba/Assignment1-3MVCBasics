using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasics.Migrations
{
    public partial class SeededsomedatatoLanguageandPersonLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Languages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Name", "PersonId" },
                values: new object[] { -1, "Swedish", null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Name", "PersonId" },
                values: new object[] { -2, "Norwegian", null });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { -1, -1 },
                    { -2, -1 },
                    { -3, -1 },
                    { -1, -2 },
                    { -3, -2 },
                    { -4, -2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_PersonId",
                table: "Languages",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_People_PersonId",
                table: "Languages",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_People_PersonId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_PersonId",
                table: "Languages");

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { -4, -2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { -3, -2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { -3, -1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Languages");
        }
    }
}
