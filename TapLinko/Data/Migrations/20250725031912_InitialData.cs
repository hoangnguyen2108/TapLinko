using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LinkPages",
                columns: table => new
                {
                    LinkPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LinkPageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPages", x => x.LinkPageId);
                    table.ForeignKey(
                        name: "FK_LinkPages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                unique: true);
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

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
