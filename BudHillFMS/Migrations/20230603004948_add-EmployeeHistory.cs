using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class addEmployeeHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmWorked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionWorked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeHistories_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "29f35689-231c-4663-a842-df302f3280a8");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fcada385-818f-4f64-acf6-a5ea70e65622");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "433c6d2e-f867-4050-96db-a549f9adceb6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fcf3446-83b8-497f-b28b-c6be8c83ec6f", "AQAAAAEAACcQAAAAECXI1egxPWBr+iT6v1pnSkBss3tF2WxeKAj8HiANscWlk1owcLsc+95kqwDpeFcxow==", "d529877d-8adf-425e-95ee-3d222a4b7ea0" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2320cb44-49f3-4d4b-936c-701b6b152d23", "AQAAAAEAACcQAAAAEIZm88zq1WnzmaAdBS5h8AHcjnUbTTlBNnTRxvxJPFKuaPnit18n01Auc/dn6jb0gA==", "bed1badb-0786-48f5-84a0-d61d3b35aee7" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aa8c617-0f04-49ec-b22b-d3847d0b75ce", "AQAAAAEAACcQAAAAENbk8v45MKQ8d6zJ6yJacYnCI0VZX0cfN486lRCKw8Ia89KdYz/NKDs/zTuALdPThQ==", "191ceed4-0589-43c3-b5af-ac43c189603d" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e9c8778-8c04-4d23-b8c1-6c1dd11b84b4", "AQAAAAEAACcQAAAAEBHJwiDNRn7d5lkiR5WLhZ3ayZDyyjbZq/bPQDI2hu6eAPjC4LbcR/nnjozkTFKLFg==", "cbf1ade4-488a-452a-a691-aed7076d652c" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e64dd945-3d92-4420-addd-ccd292258d53", "AQAAAAEAACcQAAAAEGXMKn6UbFVcug1VYPdrgSEXLwlTCOR3ISc0Wi58TVXwVR2Wdezo9Sm89QhClGi1JA==", "c946c831-61c6-42af-bdb6-6854f45930d7" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistories_EmployeeId",
                table: "EmployeeHistories",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeHistories");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "420afaf5-00d1-49ba-837a-0b84d4a3babb");

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
    }
}
