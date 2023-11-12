using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsOpenColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerChallenges");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "325ef2db-69ed-4f2d-b6dd-09c3b0f9da50");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bcbaa0ef-639f-461d-93f7-e2be80b98ca7");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d1f07830-952e-406a-8ba2-a3de145d90db", "0c1e9a06-b452-421b-a81a-7e283a3371f0" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d1f07830-952e-406a-8ba2-a3de145d90db");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0c1e9a06-b452-421b-a81a-7e283a3371f0");

            migrationBuilder.CreateTable(
                name: "PlayerChallenges",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    PrizeAmount = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerChallenges", x => new { x.PlayerId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_PlayerChallenges_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerChallenges_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3743b657-0d13-41a2-bd4a-aae2ef1c5832", "24684611-f1cd-4d9f-ab7a-506515a7658d", "Admin", "ADMIN" },
                    { "5d03e9ea-2100-4ab2-9ff0-90493462deab", "78e1e688-1b90-49b3-adaa-6406c60e70b4", "User", "USER" },
                    { "b3191c4b-e6f0-4674-883b-306ee57ef921", "23b861d1-60b8-45f9-ae9b-a15257bace26", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4283522-c40c-405f-80e8-c8870e226bc3", 0, "7d8eb310-f100-4b36-9ee0-d7e5fbd31f33", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEBS0OgCSqFBbIE2wPXjLVM2Vop7c+IMTuReJV5XuREp4w0gMg8pNGuBmysOLBCCldw==", null, false, "7313c1a5-bcec-405e-a90d-4b1192b02024", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3191c4b-e6f0-4674-883b-306ee57ef921", "e4283522-c40c-405f-80e8-c8870e226bc3" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChallenges_ChallengeId",
                table: "PlayerChallenges",
                column: "ChallengeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerChallenges");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3743b657-0d13-41a2-bd4a-aae2ef1c5832");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5d03e9ea-2100-4ab2-9ff0-90493462deab");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3191c4b-e6f0-4674-883b-306ee57ef921", "e4283522-c40c-405f-80e8-c8870e226bc3" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b3191c4b-e6f0-4674-883b-306ee57ef921");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e4283522-c40c-405f-80e8-c8870e226bc3");

            migrationBuilder.CreateTable(
                name: "ChallengePlayers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PrizeAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengePlayers", x => new { x.PlayerId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_ChallengePlayers_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "325ef2db-69ed-4f2d-b6dd-09c3b0f9da50", "dbfdf322-b1b1-492a-9773-94fa8fff3a6d", "User", "USER" },
                    { "bcbaa0ef-639f-461d-93f7-e2be80b98ca7", "dfddf6ae-8909-4d7f-a7eb-dd31bdaaac3e", "Admin", "ADMIN" },
                    { "d1f07830-952e-406a-8ba2-a3de145d90db", "b99c380e-de38-441a-98af-fa84243fca8e", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c1e9a06-b452-421b-a81a-7e283a3371f0", 0, "ef180189-5076-48cf-818d-1dc8b318ce38", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEFkQNd4ZjnG/9pJcIBHtNfS0xFnFItd2P3sxfmtGyLmOfKTZyQ3Qaz3q4H+PRwMByg==", null, false, "d849db8b-845f-46f9-bbcc-6ab27f049575", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d1f07830-952e-406a-8ba2-a3de145d90db", "0c1e9a06-b452-421b-a81a-7e283a3371f0" });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengePlayers_ChallengeId",
                table: "ChallengePlayers",
                column: "ChallengeId");
        }
    }
}
