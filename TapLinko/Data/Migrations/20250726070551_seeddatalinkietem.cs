using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeddatalinkietem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LinkItems",
                columns: new[] { "LinkItemId", "ClickCount", "Label", "LinkPageId", "Order", "Url" },
                values: new object[,]
                {
                    { 1, 0, "GitHub", 1, 1, "https://github.com/alice" },
                    { 2, 0, "Portfolio", 1, 2, "https://alice.dev" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LinkItems",
                keyColumn: "LinkItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LinkItems",
                keyColumn: "LinkItemId",
                keyValue: 2);
        }
    }
}
