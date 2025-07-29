using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class addemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LinkPages",
                type: "nvarchar(max)",
                nullable: true);

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
                column: "Email",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "LinkPages");

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
        }
    }
}
