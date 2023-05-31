using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class UserCanHaveMultipleRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 3, 3 },
                    { 2, 4 },
                    { 1, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 1,
                column: "FarmLocation",
                value: "Thịnh Sơn");

            migrationBuilder.UpdateData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 2,
                column: "FarmLocation",
                value: "Văn Sơn");

            migrationBuilder.UpdateData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 3,
                column: "FarmLocation",
                value: "Trù Sơn");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "68511b12-d092-42e5-83da-f31c247f9fdb", "Admin" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[] { "5c8a0761-2a5c-46a9-8b2f-446a53f58ef1", "Manager", "Manager", "Quản lý Farm " });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[] { "f68906b8-537b-4f45-ae7d-9a1a7757e6d1", "Engineer", "Engineer", "Kỹ thuật viên " });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 1,
                column: "FarmLocation",
                value: "Quản lý toàn bộ Farm");

            migrationBuilder.UpdateData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 2,
                column: "FarmLocation",
                value: "Quản lý Farm Thịnh Sơn");

            migrationBuilder.UpdateData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 3,
                column: "FarmLocation",
                value: "Quản lý Farm  Văn Sơn");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "e801967f-0b7b-4367-8411-ee14e64e32aa", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[] { "584f77d8-03d1-453a-9e1c-d8c4a10eda7b", "TS Manager", "TS MANAGER", "Quản lý Farm Thịnh Sơn" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[] { "a6dafebe-744c-4e87-93f3-e2cc5cf327b6", "VS Manager", "VS MANAGER", "Quản lý Farm  Văn Sơn" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[,]
                {
                    { 4, "a7983967-dcc9-4b74-b6d4-916c2a7764b3", "TS Engineer", "TS ENGINEER", "Kỹ thuật viên Thịnh Sơn" },
                    { 5, "dbfcf54b-475f-46b8-b50a-64c3dfca530b", "VS Engineer", "VS ENGINEER", "Kỹ thuật viên Văn Sơn" },
                    { 6, "0a3a5f0b-03ee-454e-b94c-ec50cea24697", "Worker", "WORKER", "Công nhân farm" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "08b6414d-3574-4e17-9d43-3920a572441b", "AQAAAAEAACcQAAAAEJ/8IKcazlipoj+xPfyIaLmw7ETpbgpj0rpWp8df6MqW9w3AmBww0Dvgx2rUd+Bx9A==", 1, "9cdf497c-a10c-4cbb-8d17-ae86b794bae3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "6c61b3a4-717a-4342-8f7a-c8237cb289c0", "AQAAAAEAACcQAAAAEDADnwSP1lyg56u+G4NixJYqa6nMxRp5Lrbal9f+frx4nVNlSdNB3dLh8hiU+7eKEw==", 1, "23dec996-b63e-4b7f-806f-9c0b664b4245" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "d8856b53-efbc-444a-b25a-782965dcb577", "AQAAAAEAACcQAAAAEInpLUyyHWe+0knj/8av+xdHBou1FCecbuItxj+0Wr+Sbz4YeMg4VzKgI3h35aaBIw==", 3, "97e46a22-abaf-4d31-a606-c413e18261b0" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "18b2a136-0ab8-46ff-9bf5-6b1c1632d1bd", "AQAAAAEAACcQAAAAEGownDZVHY307pDJ0rZUu/e1jmOF6bGkJXTMH5/c3pWhY9mV0X+rFRQWwPwpjrEFlQ==", 2, "444a6980-bd5d-45ca-ac1a-1b1f300e2db7" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "17ee8392-32fc-42a3-a950-6a2e09d6f424", "AQAAAAEAACcQAAAAEGeNmVUZjqXGwrP4l8Hx4otJLXVwRWvMRCZX1cAt4krvGcQyHHa4IedSrEA3ooLsGg==", 1, "0e747720-9439-45d3-93b9-66d85fb27eb9" });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
