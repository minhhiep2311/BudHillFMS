using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class AddProductProcessColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductProcess",
                table: "Product",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d26b8620-c890-4953-9760-f9df64b62879");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a05af1aa-bb77-47f7-baeb-f7fcbd4bb4f4");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "54827652-cfff-4411-8e30-8eff9836dfd3");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20b10145-e0d9-4818-b185-983ab976f3b3", "AQAAAAEAACcQAAAAEGZlFMk4TXA0iDKQoUwmPatMR3PiorzuRQxGd9WM1Q6pekfKGnggnwc9XkcDC6GNdg==", "58563cec-3535-43b3-8ed9-fda96e377074" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adbbd00f-1c73-4bdc-8edf-7089ffb526ad", "AQAAAAEAACcQAAAAEIdKVXdF6FpF22/iDGtCXbdi2xShYhTcE/+idX7XWfdl35QwtWkqCUOa8J66LaZo2w==", "9514d50a-46f6-40e8-9434-6298a7b94d64" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ab23fee-0311-4d91-96a2-e9016a19749f", "AQAAAAEAACcQAAAAEEDq6nlZkdMsiyCjO1ti1y1Ya2XgAuK7xAI2o4c2SAIKxHJvLPkqqmkwozqIp2iXAQ==", "2d57c923-c46f-4c0e-9a76-061c28d71255" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163512be-3c93-4220-91a6-7b97bf84f616", "AQAAAAEAACcQAAAAEGr50NvBm0/4pDLNZKnMme5bgFWOE/0/t7Gx2rWpNXLFHqir1bNlG2SI6j4SIjQU2Q==", "f625fddf-52d4-4f46-a0d5-d4f63ed49dc4" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca31c839-9bb9-4351-9917-5c5253e219f5", "AQAAAAEAACcQAAAAECkB9bnA0tiTkk1yKMi0XoeJsN9JwdZC8amT8ejahypc05aDuzME8rL14HP2Yj5Fzw==", "6651bed8-156a-490c-b96a-ac2c40c1261c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductProcess",
                table: "Product");

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
    }
}
