﻿// <auto-generated />
using System;
using BudHillFMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudHillFMS.Migrations
{
    [DbContext(typeof(FarmManagementSystemContext))]
    partial class FarmManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BudHillFMS.Models.Cost", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CostID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<decimal?>("CostAmount")
                        .HasColumnType("decimal(11,0)");

                    b.Property<DateTime?>("CostDate")
                        .HasColumnType("date");

                    b.Property<string>("CostDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CostName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Coststatus")
                        .HasColumnType("bit")
                        .HasColumnName("coststatus");

                    b.Property<int>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.HasKey("CostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FarmId");

                    b.ToTable("Cost", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.CostCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("CategoryDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId")
                        .HasName("PK__CostCate__19093A2BE15C114C");

                    b.ToTable("CostCategory", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Diary", b =>
                {
                    b.Property<int>("DiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DiaryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiaryId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DiaryCategory")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DiarySubject")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("date");

                    b.Property<int>("FieldId")
                        .HasColumnType("int")
                        .HasColumnName("FieldID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.HasKey("DiaryId");

                    b.HasIndex("FieldId");

                    b.HasIndex("ProductId");

                    b.ToTable("Diary", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("EmployeeAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeePhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("position");

                    b.HasKey("EmployeeId");

                    b.HasIndex("FarmId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EquipmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"), 1L, 1);

                    b.Property<string>("EquipmentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EquipmentQuantity")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("EquipmentUsed")
                        .HasColumnType("int");

                    b.Property<int>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.HasKey("EquipmentId");

                    b.HasIndex("FarmId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("BudHillFMS.Models.Farm", b =>
                {
                    b.Property<int>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmId"), 1L, 1);

                    b.Property<int?>("AreaUsed")
                        .HasColumnType("int");

                    b.Property<int?>("FarmArea")
                        .HasColumnType("int");

                    b.Property<string>("FarmLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FarmName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FarmId");

                    b.ToTable("Farm", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Fertilizer", b =>
                {
                    b.Property<int>("FertilizerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FertilizerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FertilizerId"), 1L, 1);

                    b.Property<DateTime?>("FertilizerImport")
                        .HasColumnType("date");

                    b.Property<string>("FertilizerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FertilizerQuantity")
                        .HasColumnType("int");

                    b.Property<string>("FertilizerType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("QuantityUsed")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int")
                        .HasColumnName("WarehouseID");

                    b.HasKey("FertilizerId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Fertilizer", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FieldID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FieldId"), 1L, 1);

                    b.Property<int>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.Property<int?>("FieldArea")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("FieldStatus")
                        .HasColumnType("bit");

                    b.HasKey("FieldId");

                    b.HasIndex("FarmId");

                    b.ToTable("Field", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("Class")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int")
                        .HasColumnName("FieldID");

                    b.Property<DateTime?>("HarvestDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("ProductStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SowingDate")
                        .HasColumnType("date");

                    b.HasKey("ProductId");

                    b.HasIndex("FieldId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Seedling", b =>
                {
                    b.Property<int>("SeedlingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeedlingId"), 1L, 1);

                    b.Property<string>("SeedlingDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SeedlingName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("SeedlingStart")
                        .HasColumnType("date");

                    b.HasKey("SeedlingId");

                    b.ToTable("Seedling", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Subtask", b =>
                {
                    b.Property<int>("SubTaskId")
                        .HasColumnType("int");

                    b.Property<string>("SubtaskName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("Subtaskstatus")
                        .HasColumnType("bit")
                        .HasColumnName("subtaskstatus");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("SubTaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("Subtasks");
                });

            modelBuilder.Entity("BudHillFMS.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<DateTime?>("DuaDate")
                        .HasColumnType("date");

                    b.Property<int>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.Property<int>("FieldId")
                        .HasColumnType("int")
                        .HasColumnName("FieldID");

                    b.Property<bool>("TaskCheck")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("date");

                    b.Property<string>("TaskDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TaskName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TaskStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TaskId");

                    b.HasIndex("FarmId");

                    b.HasIndex("FieldId");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Timekeeping", b =>
                {
                    b.Property<int>("TimekeepingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TimekeepingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimekeepingId"), 1L, 1);

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime?>("TimekeepingDate")
                        .HasColumnType("date");

                    b.HasKey("TimekeepingId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Timekeeping", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "UserName" }, "UC_User_Username")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WarehouseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"), 1L, 1);

                    b.Property<int>("FarmId")
                        .HasColumnType("int")
                        .HasColumnName("FarmID");

                    b.Property<string>("WarehouseLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WarehouseName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WarehouseId");

                    b.HasIndex("FarmId");

                    b.ToTable("Warehouse", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.WarehouseProduct", b =>
                {
                    b.Property<int>("WarehouseId")
                        .HasColumnType("int")
                        .HasColumnName("WarehouseID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("WarehouseId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("WarehouseProduct", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BudHillFMS.Models.Cost", b =>
                {
                    b.HasOne("BudHillFMS.Models.CostCategory", "Category")
                        .WithMany("Costs")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Cost_CostCategory");

                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Costs")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK_Cost_Farm");

                    b.Navigation("Category");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("BudHillFMS.Models.Diary", b =>
                {
                    b.HasOne("BudHillFMS.Models.Field", "Field")
                        .WithMany("Diaries")
                        .HasForeignKey("FieldId")
                        .IsRequired()
                        .HasConstraintName("FK_Diary_Field");

                    b.HasOne("BudHillFMS.Models.Product", "Product")
                        .WithMany("Diaries")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Diary_Product");

                    b.Navigation("Field");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BudHillFMS.Models.Employee", b =>
                {
                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Employees")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK_Employee_Farm");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("BudHillFMS.Models.Equipment", b =>
                {
                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Equipment")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK_Equipment_Farm");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("BudHillFMS.Models.Fertilizer", b =>
                {
                    b.HasOne("BudHillFMS.Models.Warehouse", "Warehouse")
                        .WithMany("Fertilizers")
                        .HasForeignKey("WarehouseId")
                        .IsRequired()
                        .HasConstraintName("FK_Fertilizer_Warehouse");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("BudHillFMS.Models.Field", b =>
                {
                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Fields")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK_Field_Farm");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("BudHillFMS.Models.Product", b =>
                {
                    b.HasOne("BudHillFMS.Models.Field", "Field")
                        .WithMany("Products")
                        .HasForeignKey("FieldId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Field");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("BudHillFMS.Models.Subtask", b =>
                {
                    b.HasOne("BudHillFMS.Models.Task", "Task")
                        .WithMany("Subtasks")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("FK__Subtasks__TaskId__625A9A57");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("BudHillFMS.Models.Task", b =>
                {
                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Tasks")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK_Task_Farm");

                    b.HasOne("BudHillFMS.Models.Field", "Field")
                        .WithMany("Tasks")
                        .HasForeignKey("FieldId")
                        .IsRequired()
                        .HasConstraintName("FK_Task_Field");

                    b.Navigation("Farm");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("BudHillFMS.Models.Timekeeping", b =>
                {
                    b.HasOne("BudHillFMS.Models.Employee", "Employee")
                        .WithMany("Timekeepings")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_Timekeeping_Employee");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BudHillFMS.Models.User", b =>
                {
                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Users")
                        .HasForeignKey("FarmId")
                        .HasConstraintName("FK_User_Farm");

                    b.HasOne("BudHillFMS.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Farm");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BudHillFMS.Models.Warehouse", b =>
                {
                    b.HasOne("BudHillFMS.Models.Farm", "Farm")
                        .WithMany("Warehouses")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK_Warehouse_Farm");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("BudHillFMS.Models.WarehouseProduct", b =>
                {
                    b.HasOne("BudHillFMS.Models.Product", "Product")
                        .WithMany("WarehouseProducts")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_WarehouseProduct_Product");

                    b.HasOne("BudHillFMS.Models.Warehouse", "Warehouse")
                        .WithMany("WarehouseProducts")
                        .HasForeignKey("WarehouseId")
                        .IsRequired()
                        .HasConstraintName("FK_WarehouseProduct_Warehouse");

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BudHillFMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BudHillFMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BudHillFMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BudHillFMS.Models.CostCategory", b =>
                {
                    b.Navigation("Costs");
                });

            modelBuilder.Entity("BudHillFMS.Models.Employee", b =>
                {
                    b.Navigation("Timekeepings");
                });

            modelBuilder.Entity("BudHillFMS.Models.Farm", b =>
                {
                    b.Navigation("Costs");

                    b.Navigation("Employees");

                    b.Navigation("Equipment");

                    b.Navigation("Fields");

                    b.Navigation("Tasks");

                    b.Navigation("Users");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("BudHillFMS.Models.Field", b =>
                {
                    b.Navigation("Diaries");

                    b.Navigation("Products");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BudHillFMS.Models.Product", b =>
                {
                    b.Navigation("Diaries");

                    b.Navigation("WarehouseProducts");
                });

            modelBuilder.Entity("BudHillFMS.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BudHillFMS.Models.Task", b =>
                {
                    b.Navigation("Subtasks");
                });

            modelBuilder.Entity("BudHillFMS.Models.Warehouse", b =>
                {
                    b.Navigation("Fertilizers");

                    b.Navigation("WarehouseProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
