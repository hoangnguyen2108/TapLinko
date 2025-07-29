using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixhugedata : Migration
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69321195-8b73-4f1a-919b-e7deee4b3909",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66efb1c8-d56e-4d99-b134-2a246376807f", "AQAAAAIAAYagAAAAEGaUJ56ijzvShWC7B3pusjbFWyOzj9TJWzV/mGbCI/j84S+pcBoXet8eJq5+LLxDfw==", "f1be4c1b-e72c-4766-9233-3b89dc40207b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44d38326-0c10-415b-9aa6-e59e86ae87d0", "AQAAAAIAAYagAAAAEPHIggEjTnL47paJCrQELGHQPSXzWDntrLUyfZxfxE+fuTEGCQAX1Jgf96hKgRLkCw==", "83e03a8d-c656-4712-b098-74c9cabd1054" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateofBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "989eb43a-82b3-43a2-b29b-1e14488286fe", 0, "8698dadb-5b14-489e-bea9-cfb52ea1a15e", null, "alice@example.com", true, "Alice", "Nguyen", false, null, "ALICE@EXAMPLE.COM", "ALICE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMklaZNj/hSmZZoH+yAeOhuL0k+03tfNLsEl7N4Gfk539WiWKw5Rg8WK4Ih+eWn/IA==", null, false, "8ed1b03a-3846-429c-83e9-347434db5b6c", false, "alice@example.com" });

            migrationBuilder.UpdateData(
                table: "LinkPages",
                keyColumn: "LinkPageId",
                keyValue: 1,
                column: "UserId",
                value: "989eb43a-82b3-43a2-b29b-1e14488286fe");

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
                values: new object[] { "ba460905-ed83-435b-b6a6-25dd450b199d", "AQAAAAIAAYagAAAAEA1AXYEvm5LwaoAbgj51N1jFPdSjFdVZ2LvM6ISKt+HGvl9UT1JyUxMTYxUhiYgY7w==", "88dcd345-345d-41b0-abba-393ced77a0f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa6890cf-8745-4f84-9fc5-b930e4047767", "AQAAAAIAAYagAAAAEN9r7nbWBs2SjgKxR8zDOoeSjfSzldv6GXKCbr2oWpJNQ4o49qZA4rwt/kgWRLnPKA==", "09de1b11-f7e5-468d-890f-758b29fa4bb6" });

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
