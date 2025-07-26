using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixprofileimageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LinkPages",
                keyColumn: "LinkPageId",
                keyValue: 1,
                column: "ProfileImageUrl",
                value: "/image/image.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LinkPages",
                keyColumn: "LinkPageId",
                keyValue: 1,
                column: "ProfileImageUrl",
                value: "https://example.com/images/alice-profile.png");
        }
    }
}
