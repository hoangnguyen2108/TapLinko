using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserNamePW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "alice@example.com", "123456" });
        }
    }
}
