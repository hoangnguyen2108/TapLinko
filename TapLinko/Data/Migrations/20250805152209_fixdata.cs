using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkPages_Users_UserId",
                table: "LinkPages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_LinkPages_UserId",
                table: "LinkPages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LinkPages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LinkPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicSlug",
                table: "LinkPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69321195-8b73-4f1a-919b-e7deee4b3909",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b97068b2-38bd-4f6a-b553-24192d520ea6", "AQAAAAIAAYagAAAAEACM8461VFUVQjzKU7imwRAR2phfSiWvP4hoSitKV+kAoLL6rZicWHyHe/IGw/U8Xg==", "412cccbe-2506-4c08-b359-d7ff4905303b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7ee735b-03f1-4af4-8923-2d627662848a", "AQAAAAIAAYagAAAAEPtXH49Tg3VvPMDO0hljKrZBXmqi2eqLO8qUlswAHIIcXImGp/gm9MBTET0dXFPL9Q==", "fca0e108-6992-4ad0-804c-e21fb9710f12" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateofBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "989eb43a-82b3-43a2-b29b-1e14488286fe", 0, "01e03f4e-e340-4ae8-a97f-ef76eacb3cd2", null, "alice@example.com", true, "Alice", "Nguyen", false, null, "ALICE@EXAMPLE.COM", "ALICE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHRaE5457JJdHqMiag7kMOokO6E1wU6IujEIKC/xqtCEhGLQplXFxOZoSwtlqptHzQ==", null, false, "fb628e5b-b73b-4ba9-8aa8-d04409801045", false, "alice@example.com" });

            migrationBuilder.UpdateData(
                table: "LinkPages",
                keyColumn: "LinkPageId",
                keyValue: 1,
                columns: new[] { "Email", "PublicSlug", "UserId" },
                values: new object[] { null, null, "989eb43a-82b3-43a2-b29b-1e14488286fe" });

            migrationBuilder.CreateIndex(
                name: "IX_LinkPages_UserId",
                table: "LinkPages",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkPages_AspNetUsers_UserId",
                table: "LinkPages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkPages_AspNetUsers_UserId",
                table: "LinkPages");

            migrationBuilder.DropIndex(
                name: "IX_LinkPages_UserId",
                table: "LinkPages");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "989eb43a-82b3-43a2-b29b-1e14488286fe");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LinkPages");

            migrationBuilder.DropColumn(
                name: "PublicSlug",
                table: "LinkPages");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LinkPages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69321195-8b73-4f1a-919b-e7deee4b3909",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3a6d60c-878d-4fc1-a023-b73ca77a3b6a", "AQAAAAIAAYagAAAAEFPvLSPM0CupfiPTmG4dTISBSFlQ1DRhTuAdm7eGqveojFsji7nfWuXD61E+eDLQsg==", "b7b886f6-d07a-44e5-b505-a766754debae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b4b7386-109a-4648-9c81-1be716e6bbe5", "AQAAAAIAAYagAAAAEIDz5vA6+ioxsswh1DQSSbZ7j2D/x6ht+un76uIhWRmmrMnWTMXLD83lfTjvjY9m7g==", "c295192e-fc47-48db-a6a2-4ea330ee6fdb" });

            migrationBuilder.UpdateData(
                table: "LinkPages",
                keyColumn: "LinkPageId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { 1, null, "Alice Nguyen", null });

            migrationBuilder.CreateIndex(
                name: "IX_LinkPages_UserId",
                table: "LinkPages",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkPages_Users_UserId",
                table: "LinkPages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
