using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class SeedFieldRoleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Role",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Farm",
                columns: new[] { "FarmID", "AreaUsed", "FarmArea", "FarmLocation", "FarmName" },
                values: new object[,]
                {
                    { 1, 5, 10, "Quản lý toàn bộ Farm", "Bud Hill Thịnh Sơn" },
                    { 2, 12, 26, "Quản lý Farm Thịnh Sơn", "Bud Hill Farm Văn Sơn" },
                    { 3, 5, 5, "Quản lý Farm  Văn Sơn", "Bud Hill Trù Sơn" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[,]
                {
                    { 1, "e801967f-0b7b-4367-8411-ee14e64e32aa", "Admin", "ADMIN", "Quản lý toàn bộ Farm" },
                    { 2, "584f77d8-03d1-453a-9e1c-d8c4a10eda7b", "TS Manager", "TS MANAGER", "Quản lý Farm Thịnh Sơn" },
                    { 3, "a6dafebe-744c-4e87-93f3-e2cc5cf327b6", "VS Manager", "VS MANAGER", "Quản lý Farm  Văn Sơn" },
                    { 4, "a7983967-dcc9-4b74-b6d4-916c2a7764b3", "TS Engineer", "TS ENGINEER", "Kỹ thuật viên Thịnh Sơn" },
                    { 5, "dbfcf54b-475f-46b8-b50a-64c3dfca530b", "VS Engineer", "VS ENGINEER", "Kỹ thuật viên Văn Sơn" },
                    { 6, "0a3a5f0b-03ee-454e-b94c-ec50cea24697", "Worker", "WORKER", "Công nhân farm" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FarmID", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "08b6414d-3574-4e17-9d43-3920a572441b", "thaiminhhiep2311@gmail.com", false, 1, "Hiệp", "Thái Minh", false, null, "THAIMINHHIEP2311@GMAIL.COM", "MINHHIEP", "AQAAAAEAACcQAAAAEJ/8IKcazlipoj+xPfyIaLmw7ETpbgpj0rpWp8df6MqW9w3AmBww0Dvgx2rUd+Bx9A==", null, false, 1, "9cdf497c-a10c-4cbb-8d17-ae86b794bae3", false, "minhhiep" },
                    { 2, 0, "6c61b3a4-717a-4342-8f7a-c8237cb289c0", "thaiminhhiep2311@gmail.com", false, 1, "Minh", "Nguyễn Công", false, null, "THAIMINHHIEP2311@GMAIL.COM", "MINHNCBK", "AQAAAAEAACcQAAAAEDADnwSP1lyg56u+G4NixJYqa6nMxRp5Lrbal9f+frx4nVNlSdNB3dLh8hiU+7eKEw==", null, false, 1, "23dec996-b63e-4b7f-806f-9c0b664b4245", false, "minhncbk" },
                    { 3, 0, "d8856b53-efbc-444a-b25a-782965dcb577", "tuanthai@gmail.com", false, 2, "Tuấn", "Thái", false, null, "TUANTHAI@GMAIL.COM", "TUANTHAI", "AQAAAAEAACcQAAAAEInpLUyyHWe+0knj/8av+xdHBou1FCecbuItxj+0Wr+Sbz4YeMg4VzKgI3h35aaBIw==", null, false, 3, "97e46a22-abaf-4d31-a606-c413e18261b0", false, "tuanthai" },
                    { 4, 0, "18b2a136-0ab8-46ff-9bf5-6b1c1632d1bd", "hoantuan@hacovina.vn", false, 1, "Tuấn", "Hoàng", false, null, "HOANTUAN@HACOVINA.VN", "HOANGTUAN", "AQAAAAEAACcQAAAAEGownDZVHY307pDJ0rZUu/e1jmOF6bGkJXTMH5/c3pWhY9mV0X+rFRQWwPwpjrEFlQ==", null, false, 2, "444a6980-bd5d-45ca-ac1a-1b1f300e2db7", false, "hoangtuan" },
                    { 5, 0, "17ee8392-32fc-42a3-a950-6a2e09d6f424", "conghaice@gmail.com", false, 1, "Hải", "Nguyễn Công", false, null, "CONGHAICE@GMAIL.COM", "CONGHAI", "AQAAAAEAACcQAAAAEGeNmVUZjqXGwrP4l8Hx4otJLXVwRWvMRCZX1cAt4krvGcQyHHa4IedSrEA3ooLsGg==", null, false, 1, "0e747720-9439-45d3-93b9-66d85fb27eb9", false, "conghai" }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Role");

            migrationBuilder.DeleteData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farm",
                keyColumn: "FarmID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
