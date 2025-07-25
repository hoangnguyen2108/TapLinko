using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class linkpageuserdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { 1, "alice@example.com", "Alice Nguyen", "123456" });

            migrationBuilder.InsertData(
                table: "LinkPages",
                columns: new[] { "LinkPageId", "BannerImageUrl", "Bio", "LinkPageTitle", "ProfileImageUrl", "UserId" },
                values: new object[] { 1, "https://example.com/images/banner.png", "Welcome to my page! 💖", "Alice's Bio", "https://example.com/images/alice-profile.png", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LinkPages",
                keyColumn: "LinkPageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
