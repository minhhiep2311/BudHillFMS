using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class RemoveUnicode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "WarehouseProduct",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SubtaskName",
                table: "Subtasks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "WarehouseProduct",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SubtaskName",
                table: "Subtasks",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "68511b12-d092-42e5-83da-f31c247f9fdb");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5c8a0761-2a5c-46a9-8b2f-446a53f58ef1");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f68906b8-537b-4f45-ae7d-9a1a7757e6d1");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd03a059-245d-4bab-ad28-552f13de22ba", "AQAAAAEAACcQAAAAEF9KUgTeq5yBDAbkh7CgUdBVe+VvZmdtd2t1zq/SG9LIWER8CHHxXAJHHGuzc3eQeQ==", "223e9f4a-5819-4469-87bd-388303634549" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4843bba3-097f-4368-9436-7f37e0ef92c9", "AQAAAAEAACcQAAAAEEAgJbK3WHUPI5+JTmVPoWIvlBvSioGGCJEQSvbsr6YlsNJ5zWWJSVt6xL6OkrqmIg==", "93b80be6-a4a1-4110-8dd8-31c7e52019e6" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3402ca73-e2a7-4d43-a79a-4d6719267677", "AQAAAAEAACcQAAAAENa37IQicXmCK4NoKt1gFu56hu0Dyc4ikWR1KfT9HCyv21qf1mzYRsHJ8Lx9jO/JxA==", "e29f5648-d881-4e8c-9217-af2df4cd12b1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16a83f13-cda3-4dcd-96ca-edabb4960d71", "AQAAAAEAACcQAAAAEAKv/2L1ThefTApgVHMxqXM036wkaraMymNNN91F45PiCf6rwWDHpm1UOUXQSkEJxA==", "da8746f1-8cac-4c28-8953-98358f00f75c" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3394f46e-825d-41ee-8644-125e15120e1f", "AQAAAAEAACcQAAAAENwAGW3exygpxKB5tdGUgj0bktgwTPW9pJaE9VDFIHAKPfVFPWLi8uf+dxcih+ENBQ==", "a463c08a-26f7-4c00-a421-6eddcbbf8bb5" });
        }
    }
}
