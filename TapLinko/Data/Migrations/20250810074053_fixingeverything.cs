using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixingeverything : Migration
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

            migrationBuilder.CreateTable(
                name: "LinkPages",
                columns: table => new
                {
                    LinkPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkPageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicSlug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPages", x => x.LinkPageId);
                    table.ForeignKey(
                        name: "FK_LinkPages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LinkItems",
                columns: table => new
                {
                    LinkItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    LinkPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkItems", x => x.LinkItemId);
                    table.ForeignKey(
                        name: "FK_LinkItems_LinkPages_LinkPageId",
                        column: x => x.LinkPageId,
                        principalTable: "LinkPages",
                        principalColumn: "LinkPageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClickEvents",
                columns: table => new
                {
                    ClickEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateOnly>(type: "date", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickEvents", x => x.ClickEventId);
                    table.ForeignKey(
                        name: "FK_ClickEvents_LinkItems_LinkItemId",
                        column: x => x.LinkItemId,
                        principalTable: "LinkItems",
                        principalColumn: "LinkItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { "69321195-8b73-4f1a-919b-e7deee4b3909", 0, "5b247533-0c10-438c-802f-425d80c83468", new DateOnly(1990, 1, 1), "user1admin@gmail.com", true, "Jay", "Van", false, null, "USER1ADMIN@GMAIL.COM", "USER1ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEA52iY1zokmNvPsWufBQKb9NnNTA3EdSU9BApGr2q8ixZP3WYhpO0uVq2Tdt80goVA==", null, false, "4ba6c652-75a8-4683-a0d6-4373a3fa2d6f", false, "user1admin@gmail.com" },
                    { "989eb43a-82b3-43a2-b29b-1e14488286fe", 0, "5df8d6d9-a88f-4eaf-b9d4-c99b8ef00aa8", null, "alice@example.com", true, "Alice", "Nguyen", false, null, "ALICE@EXAMPLE.COM", "ALICE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMjyl04QINaS8Ocy1H36qU5BsaoIZgknptWgSBVHIslHbyqakDBmlkZn0N1TwCZM6A==", null, false, "9a72d81c-ac14-4337-9b4c-d34bb9fe3ea1", false, "alice@example.com" },
                    { "bdee7c76-d0b8-4ff2-908c-f80177687964", 0, "421a6230-62ab-43ad-9e98-189996ad234a", new DateOnly(1992, 2, 2), "user2sup@gmail.com", true, "John", "Doe", false, null, "USER2SUP@GMAIL.COM", "USER2SUP@GMAIL.COM", "AQAAAAIAAYagAAAAEMNHE8do/tZdK4TlUGH9N9LEAsb0ONRmSHyHtyxz1EcPm1s5wahYN+voLHBI2ZGZgg==", null, false, "e6d418f9-f6c2-4dd5-87f9-cbcb81cc7676", false, "user2sup@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b", "69321195-8b73-4f1a-919b-e7deee4b3909" },
                    { "f4145e80-361d-4541-b311-9e95b4a95964", "bdee7c76-d0b8-4ff2-908c-f80177687964" }
                });

            migrationBuilder.InsertData(
                table: "LinkPages",
                columns: new[] { "LinkPageId", "BannerImageUrl", "Bio", "Email", "LinkPageTitle", "ProfileImageUrl", "PublicSlug", "UserId" },
                values: new object[] { 1, "https://example.com/images/banner.png", "Welcome to my page! 💖", null, "Alice's Bio", "/image/image.jpeg", null, "989eb43a-82b3-43a2-b29b-1e14488286fe" });

            migrationBuilder.InsertData(
                table: "LinkItems",
                columns: new[] { "LinkItemId", "ClickCount", "Label", "LinkPageId", "Order", "Url" },
                values: new object[,]
                {
                    { 1, 0, "GitHub", 1, 1, "https://github.com/alice" },
                    { 2, 0, "Portfolio", 1, 2, "https://alice.dev" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClickEvents_LinkItemId",
                table: "ClickEvents",
                column: "LinkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkItems_LinkPageId",
                table: "LinkItems",
                column: "LinkPageId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPages_UserId",
                table: "LinkPages",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClickEvents");

            migrationBuilder.DropTable(
                name: "LinkItems");

            migrationBuilder.DropTable(
                name: "LinkPages");

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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "989eb43a-82b3-43a2-b29b-1e14488286fe");

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
