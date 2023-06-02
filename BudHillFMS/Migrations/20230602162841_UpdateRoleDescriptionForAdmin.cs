using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class UpdateRoleDescriptionForAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RoleDescription" },
                values: new object[] { "420afaf5-00d1-49ba-837a-0b84d4a3babb", "Admin" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "affd9a9f-f312-4e00-b6d8-b267eaae84ff");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b8a58d93-6014-499b-9585-12da18c15a31");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3f85101-2376-4280-bcf7-6109f367f1d6", "AQAAAAEAACcQAAAAEI9EInv0nxBQAKb1RdVpSggJa42F2yGb1jmNmGz5cQJLz8hUI8/kIOWj7Xq41JmpJA==", "8d5effe1-b182-42fc-809f-8934b2523ca9" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c39514a6-5c20-4d89-97e6-a3a15925add8", "AQAAAAEAACcQAAAAEGq/nX7T6AwfHf6hMU4EekQRui2rilOCl/giBnxp8nvrlteyNBLF4RuE7ipbkkP2kQ==", "5753e2db-d296-4a42-a48c-8edc660a9104" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3f21a97-b1b3-43e4-b6b8-673d3663241e", "AQAAAAEAACcQAAAAEJaEfjVXnfKs20zFNngOIN05z8Js5tQu04BxUQIEPDj09V3LxmHDPzxtR0OBr6rt+g==", "4ed14dee-28e9-42ab-9f72-82dfacf3c9a2" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c7d8a48-1a43-4665-bdff-195aeb7a0573", "AQAAAAEAACcQAAAAECtuaxAj9UywAPiNrGYbxoqTx59bbtc6uYN4TCuDaHbvoXIGEiux1XLDAQD+ONZz6Q==", "b6d07adf-d6e2-4ae4-9b77-44d80dfa4d4b" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f283f2-b09e-4ba6-8a0d-ce1bf1f0b9b5", "AQAAAAEAACcQAAAAEHyvPZvtYK7E4wvEstJVr3tjss8rt4KyEUHEuOsyTZ64gOmWcOftkU4m9IYSBzz+Zg==", "aafa7054-30fd-489a-942d-49b600edda0a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RoleDescription" },
                values: new object[] { "c0dfdaae-a563-4c3f-93c0-648193bbc5da", "Quản lý toàn bộ Farm" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "76b6b6e8-ba49-4896-8282-1060cc25c8e7");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "bc74508c-6176-4e86-8ca7-a6e00a93c382");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076d6760-34ef-4a19-87e3-285f59860dd1", "AQAAAAEAACcQAAAAEMk6kVRWsgcGhX4KUmXe9PPHab4MMDEpVgtuDVm45OEif5UnYJ38icxciDeKGbx4uA==", "794225f6-3bdf-4e43-863a-7381306ab20f" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e3fa330-45e4-455d-be98-516bdb5bb86d", "AQAAAAEAACcQAAAAEOGh1CEkOX78Uh8xAoNjI3QeBnTycQwkb6pXfxwViiF4F401j6ua0hDFZdsds4Er6g==", "22126a3f-932d-485b-a9d6-dace67432518" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dee77f78-6c06-47f5-b049-40c5c80cc63d", "AQAAAAEAACcQAAAAEDZ0+n3gTMn1M01WHp32JhkjGYKv9aoaRQKRLLhJ7RG/0Ny67aU0kpAYoDZFSmsFKw==", "b0d8a927-9d97-480e-b1dc-d66d81b8af1b" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fb9f534-1899-490d-8e33-f6a5007380a5", "AQAAAAEAACcQAAAAECnZAd2T6qZKwRX8Vrt6JJzk9Thfctq2hmuSWnSYUW5tVHcIrz0JcfOVbmRpB4GBOw==", "9936740d-39fd-4bef-8ab3-e837f3db484e" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae8ecff3-467a-4321-aa48-ae463bdee8ee", "AQAAAAEAACcQAAAAEO4opPa77fmqJ34y6y+7TJQW7pbndcbXAZonflBC84/JMfrc7uTjTaXRqr5pbJ+wqA==", "705c9f15-e364-40d2-b136-40d922ded886" });
        }
    }
}
