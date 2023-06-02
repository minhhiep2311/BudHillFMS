using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class diary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diary",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ec440feb-b0a8-4668-a14f-1bf007f27a26");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6b042594-839a-44b2-90ee-0ea251a3da7f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "903d27ed-b867-4660-99e0-0450403e5525");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "571348aa-df40-49a9-8171-42cd49622b78", "AQAAAAEAACcQAAAAEBw+08nz3/mZX8PffDVzWpfxq/502LON1wi0DR1hJkIpdWY87ZqZSgTfWSTPO/bLPw==", "dac41270-1fb6-4871-8475-e344dd239b5e" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23d96920-85ad-4100-a57f-9a11945a07de", "AQAAAAEAACcQAAAAEKYXAboT9nyf0KxrUmSDvlD33Byx4+G3eIcMDdj6+TiuB4Z2cukLkC2Dijdqu7/dng==", "91e411d5-61e4-4cbf-a6c3-bd90cf172317" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bcf887d-7c5b-4f22-abca-a4e92619c31f", "AQAAAAEAACcQAAAAEHbZ2HcfApECYrm8dHYsc9GDlkP+AyB87u/mMGfjesfJ9+i8LWRheU1gJj7CJzx0YQ==", "a0e7b36d-5cf8-4e1e-8baa-e60f83a803a1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1225fa8a-47d1-4f3f-9adf-74f87ddb1e89", "AQAAAAEAACcQAAAAEN0R0nDh9wsQ/S0N7UaX/7780NwdkPiawVkmr0MlOu/boqjLvakMXIAe2dTtpfwwcg==", "18c8c40f-a67b-47d1-9de3-08ed42654846" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8911a4b-cb04-48fa-beec-62ecb10035d2", "AQAAAAEAACcQAAAAEOx8HUWJ3d4hXoyzolB5z2siY3obhJRrKM8b2pt9upN/S490nYGMQ1wpTFy9fAp2UA==", "80224abb-6ecf-48cb-9fce-8cc9bdbffc53" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diary",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1da42e52-18d2-4f1a-bbc5-3b31ce13e0fa");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8d2abf1f-e80e-4663-a878-aaba0ff39078");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "227bae35-3658-4744-a51e-b4beb9e1e3b0");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "865850e0-dcbb-4e55-ad39-97ef2bce4f8c", "AQAAAAEAACcQAAAAEFtSm7wnKwTFOenj6+8KwzsFZd85rb5ZyFj4bnaVQwjAPr+lnUVQnrMBTElrzA6tSQ==", "aa9d274e-6297-4277-8e0d-d1e0c38cfa71" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2b554f3-0931-4da2-92a2-cadc473256bc", "AQAAAAEAACcQAAAAEDQWwKQE4uXUemlqTxBZ83OZ8TdRf+hBbbnyhD+0szjAc4N4icBpNHZezzM4jn26bg==", "5df40c23-cc7c-465b-9509-c60990b32db5" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "252552fe-59a5-4fba-b8d4-615d5e8ace47", "AQAAAAEAACcQAAAAED4Mo7BP2UqlJKmCe4dX+666God+kzhuXmWwzW4vD2gelGz+en0S2hgS4kYaG12SwQ==", "9d84208b-953d-4847-b31b-416eb913de1b" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af24fa7a-4bc2-4447-931e-3bacb935d046", "AQAAAAEAACcQAAAAEKQVPkRaLjEKnctCnZVTYBfizveQAcemSWANfLS+DL3D2y3CJkRD5A5JniDMPyEghQ==", "6cda5212-ca6f-49ed-a08b-42de3d65f3e3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b83af64-11b5-4016-b44a-12fe91ec9cd9", "AQAAAAEAACcQAAAAEPuj1dFzCQDduYs3af5xP58QxG0ODM8462y+QyNdQl6vLKtBMi8giAImoXlrwzx9Jw==", "1a8eca1b-a157-4ed7-8867-7730e6a123cd" });
        }
    }
}
