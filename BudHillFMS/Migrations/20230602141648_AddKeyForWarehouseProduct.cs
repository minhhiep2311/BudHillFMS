using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudHillFMS.Migrations
{
    public partial class AddKeyForWarehouseProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseProduct",
                table: "WarehouseProduct");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseProduct_ProductID",
                table: "WarehouseProduct");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WarehouseProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseProduct",
                table: "WarehouseProduct",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c0dfdaae-a563-4c3f-93c0-648193bbc5da");

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

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProduct_WarehouseID",
                table: "WarehouseProduct",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "UC_WarehouseProduct_ProductId_WarehouseId",
                table: "WarehouseProduct",
                columns: new[] { "ProductID", "WarehouseID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseProduct",
                table: "WarehouseProduct");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseProduct_WarehouseID",
                table: "WarehouseProduct");

            migrationBuilder.DropIndex(
                name: "UC_WarehouseProduct_ProductId_WarehouseId",
                table: "WarehouseProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WarehouseProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseProduct",
                table: "WarehouseProduct",
                columns: new[] { "WarehouseID", "ProductID" });

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

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProduct_ProductID",
                table: "WarehouseProduct",
                column: "ProductID");
        }
    }
}
