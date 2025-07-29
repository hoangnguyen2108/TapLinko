using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapLinko.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddataonlinkitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69321195-8b73-4f1a-919b-e7deee4b3909",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "535d1796-7039-4187-a297-a51042c9e60e", "AQAAAAIAAYagAAAAEMmRjVXxwonwAjHxrAYZXPHRyfU7/Sv6ldAGf9GYPm7rsXvuTTY7ua6TBzWgg8DHEg==", "b2ea9933-54bb-483b-a62a-4393dbdd7589" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "989eb43a-82b3-43a2-b29b-1e14488286fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1093ca4a-e36a-4cac-8de7-5b60cc31609f", "AQAAAAIAAYagAAAAEIbuWlL86v+5mffj45RtpUnnUY09z1cbPrReYQnpLcqlgog4I3O1Iw9SLnJKaQ7efg==", "3e8f1305-db54-4d25-a0fd-95f6266bf240" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85016005-f514-4a05-93a9-a56ff6a7ce17", "AQAAAAIAAYagAAAAEM6NCGYLlht15Nxe2LfYL8+qsYBCO+gRVY+rtAcdTnxh3udBld5RvoPSomr9lqK7sA==", "e72aebbc-13d2-4fd6-a4c7-6f670b2f3f2f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69321195-8b73-4f1a-919b-e7deee4b3909",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66efb1c8-d56e-4d99-b134-2a246376807f", "AQAAAAIAAYagAAAAEGaUJ56ijzvShWC7B3pusjbFWyOzj9TJWzV/mGbCI/j84S+pcBoXet8eJq5+LLxDfw==", "f1be4c1b-e72c-4766-9233-3b89dc40207b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "989eb43a-82b3-43a2-b29b-1e14488286fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8698dadb-5b14-489e-bea9-cfb52ea1a15e", "AQAAAAIAAYagAAAAEMklaZNj/hSmZZoH+yAeOhuL0k+03tfNLsEl7N4Gfk539WiWKw5Rg8WK4Ih+eWn/IA==", "8ed1b03a-3846-429c-83e9-347434db5b6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee7c76-d0b8-4ff2-908c-f80177687964",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44d38326-0c10-415b-9aa6-e59e86ae87d0", "AQAAAAIAAYagAAAAEPHIggEjTnL47paJCrQELGHQPSXzWDntrLUyfZxfxE+fuTEGCQAX1Jgf96hKgRLkCw==", "83e03a8d-c656-4712-b098-74c9cabd1054" });
        }
    }
}
