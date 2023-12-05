using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCascadeBattle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3798e468-94da-4c5c-ba43-ec4cdc814098", "AQAAAAIAAYagAAAAEMjiE4hj2b6O2JrLYc05pPV31klJJsQMD5cu34I8M8vGztI/Mquzy5RYT1EGs0WG2A==", "d55db1d2-80e2-4dce-84d0-bf57da0d8950" });

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles",
                column: "LoserId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0e2abdea-6c7f-45f6-95f7-2a1bcb80762e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96389203-4e28-4320-a35a-3ed4e3009318", "AQAAAAIAAYagAAAAEC4PnhS3Je6adL/gpYjbpY+8k09MpPMSGUqYCumjoio2NA00was8/e0FJwWEU62ENA==", "5146e4b5-3264-4bac-87c5-dff26f56e4ed" });

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles",
                column: "LoserId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
