using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixIsOpenColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3a147a45-80de-461d-aee5-d6d6606b911a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b6cdc8fd-6b77-4971-a0f1-2818605effa2");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49cf16a2-9ce6-48c5-89cc-c37177064e19", "c2371383-2549-452c-a9f5-5aa4a910615e" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "49cf16a2-9ce6-48c5-89cc-c37177064e19");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c2371383-2549-452c-a9f5-5aa4a910615e");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Challenges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44676194-6ae3-4dfc-8eb1-d68f12bf6d6f", "4c76eb19-9e9e-41da-b9ee-ca5b1d75b729", "User", "USER" },
                    { "d5c20944-0ff0-4488-9926-6a6d021b086b", "c7626288-c2b8-4cf1-aedf-170053f48796", "Admin", "ADMIN" },
                    { "ecd78557-7dad-4ae6-833b-26976c0ddc8b", "a8886c80-94cb-4401-b2b3-b6e0ce3263dc", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1026f93f-8c56-4429-8815-fb01aa6988fd", 0, "17e10981-8252-40e2-bd4c-0a82122a1ec2", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHE/PrOxd4K+YKsvXyAHu4YMk9sWf74V4Y2ZV0aReaJYGrcfF8ZmNquK23dvsw9QoQ==", null, false, "9f434fab-decd-4fd8-b451-e001d60d6774", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ecd78557-7dad-4ae6-833b-26976c0ddc8b", "1026f93f-8c56-4429-8815-fb01aa6988fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "44676194-6ae3-4dfc-8eb1-d68f12bf6d6f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5c20944-0ff0-4488-9926-6a6d021b086b");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ecd78557-7dad-4ae6-833b-26976c0ddc8b", "1026f93f-8c56-4429-8815-fb01aa6988fd" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ecd78557-7dad-4ae6-833b-26976c0ddc8b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1026f93f-8c56-4429-8815-fb01aa6988fd");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Challenges");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a147a45-80de-461d-aee5-d6d6606b911a", "c2e56e79-867f-4654-90e1-824068b05b05", "Admin", "ADMIN" },
                    { "49cf16a2-9ce6-48c5-89cc-c37177064e19", "71315f54-9820-4973-9a71-4eca29828525", "SuperAdmin", "SUPERADMIN" },
                    { "b6cdc8fd-6b77-4971-a0f1-2818605effa2", "3a2c0ad7-589e-4de1-a705-d899688e6986", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2371383-2549-452c-a9f5-5aa4a910615e", 0, "6ab90809-d3d4-41a1-b19a-865bf0d5e985", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEATpKFO5EkvBg2L4NwKW4hZu2nD+i86Sy1+NwZ/J4AmiFOuy9DDa/0NenkWfYTnl0g==", null, false, "afa3c72c-7788-4ea1-8c6f-c6ebd0e95415", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "49cf16a2-9ce6-48c5-89cc-c37177064e19", "c2371383-2549-452c-a9f5-5aa4a910615e" });
        }
    }
}
