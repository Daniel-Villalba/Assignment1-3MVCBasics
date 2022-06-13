using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasics.Migrations
{
    public partial class Seededrolesandaddeddefaultadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cfcbf57-1ed7-4b91-998f-1f1069bff8d9", "f9eae320-77eb-4da9-9471-ea6ffb01e2ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c32c611-e0e3-4374-9e1a-68caa1e96797", "241b91fd-3425-4c8d-887d-7a36b86bd482", "Standard", "STANDARD" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFirstName", "UserLastName", "UserName" },
                values: new object[] { "f0469b3c-0ff9-47f1-801e-c669452e8b0d", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "680d61e8-dc33-47f2-a2a0-d0e413d51b67", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIgO+sZNiR2yFf4te77YgKj0dTDAJ+c6uuqoasuX9OqDWWDS5FsKzPyPul8kyReIBA==", null, false, "5ed074a5-310f-42a3-b053-e8066dbc1849", false, null, null, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f0469b3c-0ff9-47f1-801e-c669452e8b0d", "0cfcbf57-1ed7-4b91-998f-1f1069bff8d9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c32c611-e0e3-4374-9e1a-68caa1e96797");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f0469b3c-0ff9-47f1-801e-c669452e8b0d", "0cfcbf57-1ed7-4b91-998f-1f1069bff8d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cfcbf57-1ed7-4b91-998f-1f1069bff8d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0469b3c-0ff9-47f1-801e-c669452e8b0d");
        }
    }
}
