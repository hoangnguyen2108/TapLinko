using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class addidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateofBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b", null, "Administrator", "ADMINISTRATOR" },
                    { "958e6340-4275-49ed-80ee-2cb5e2fad807", null, "Employee", "EMPLOYEE" },
                    { "f4145e80-361d-4541-b311-9e95b4a95964", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateofBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69321195-8b73-4f1a-919b-e7deee4b3909", 0, "e3a6d60c-878d-4fc1-a023-b73ca77a3b6a", new DateOnly(1990, 1, 1), "user1adin@gmail.com", true, "Jay", "Van", false, null, "USER1admin@GMAIL.COM", "USER1admin", "AQAAAAIAAYagAAAAEFPvLSPM0CupfiPTmG4dTISBSFlQ1DRhTuAdm7eGqveojFsji7nfWuXD61E+eDLQsg==", null, false, "b7b886f6-d07a-44e5-b505-a766754debae", false, "user1admin" },
                    { "bdee7c76-d0b8-4ff2-908c-f80177687964", 0, "5b4b7386-109a-4648-9c81-1be716e6bbe5", new DateOnly(1992, 2, 2), "user2sup@gmail.com", true, "John", "Doe", false, null, "USER2SUP@GMAIL.COM", "USER2SUP", "AQAAAAIAAYagAAAAEIDz5vA6+ioxsswh1DQSSbZ7j2D/x6ht+un76uIhWRmmrMnWTMXLD83lfTjvjY9m7g==", null, false, "c295192e-fc47-48db-a6a2-4ea330ee6fdb", false, "user2sup" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b", "69321195-8b73-4f1a-919b-e7deee4b3909" },
                    { "f4145e80-361d-4541-b311-9e95b4a95964", "bdee7c76-d0b8-4ff2-908c-f80177687964" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "958e6340-4275-49ed-80ee-2cb5e2fad807");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b", "69321195-8b73-4f1a-919b-e7deee4b3909" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4145e80-361d-4541-b311-9e95b4a95964", "bdee7c76-d0b8-4ff2-908c-f80177687964" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4145e80-361d-4541-b311-9e95b4a95964");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69321195-8b73-4f1a-919b-e7deee4b3909");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964");

            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
