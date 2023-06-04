using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class AddFieldEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FarmWorked",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionWorked",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "38176a8d-bf7d-436d-8ea1-50c0d5303f41");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "020eae44-c078-48d5-931f-04441cfb876d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "84fad961-2f1c-4411-b167-b48fc530398c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d6b530-c651-498e-bbc4-a16cae8d91a7", "AQAAAAEAACcQAAAAEH9RMetG/tRFrQ2yCxcc8azJZq4PmuIr5gfCmlVEPgFDAp3SubS1Z2boSdRS05B+nQ==", "5e3b1249-defb-44d9-9e3e-f26fd67bd491" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66a29d45-0b81-44e2-b42f-390091bbac4b", "AQAAAAEAACcQAAAAEBCKEbZbx9ZaEh9kVRMTtjbzmQ6r0goU8lCHOzz98ARxClBmB3Ckp7HPUoyG/VLfmQ==", "9aa83d6f-aef7-4207-a149-53ee028cd4b1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c802e4-792a-4a0f-9847-540049532314", "AQAAAAEAACcQAAAAEAmPxZ5phjnb1wnDpreSdFo7jUq2ETd9187GJiajCkvHnJOpTNmkwKOlMMQNDEraEA==", "735f8044-be88-48c1-b9c2-825947906fb4" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "343673a2-032f-435c-88b2-bdabbb258d55", "AQAAAAEAACcQAAAAEGJ9PHQnL9OUfpr1n9Y/WCfDTUjbhUxpUNRwoGUtsK+2GXKmkXNVyv0LY8KJmmWGsg==", "d7c31209-9270-48cd-ba79-92dced4e3afc" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdb352e2-c589-4c46-814f-cbd337e64a69", "AQAAAAEAACcQAAAAEBwFrH9GVYYb403woly3ijnN56Nc1TGnmCeVTeDTHql+ze5K+uOlFvPKeSznqW/wPA==", "eb2f2aef-d8c8-444f-8b0d-276ce2f73590" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmWorked",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PositionWorked",
                table: "Employee");

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
        }
    }
}
