using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2138f6e3-9d68-4a9e-8f2e-986af2b353ea", "AQAAAAIAAYagAAAAECpenFCJ+HItHliu2yQuU6Y+u7r7AeVrJ3tPkw1j0rM4kkGEOmZlChwaBpLtMGo4zw==", "d7b758d4-de3f-4e8b-94dd-b53b6c3cdbea" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3798e468-94da-4c5c-ba43-ec4cdc814098", "AQAAAAIAAYagAAAAEMjiE4hj2b6O2JrLYc05pPV31klJJsQMD5cu34I8M8vGztI/Mquzy5RYT1EGs0WG2A==", "d55db1d2-80e2-4dce-84d0-bf57da0d8950" });
        }
    }
}
