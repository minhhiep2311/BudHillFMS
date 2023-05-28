using BudHillFMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = BudHillFMS.Models.Task;

namespace BudHillFMS.Areas.Identity.Data;

public partial class FarmManagementSystemContext : IdentityDbContext<User, Role, int>
{
    public FarmManagementSystemContext(DbContextOptions<FarmManagementSystemContext> options)
        : base(options) { }

    public virtual DbSet<Cost> Costs { get; set; } = null!;
    public virtual DbSet<CostCategory> CostCategories { get; set; } = null!;
    public virtual DbSet<Diary> Diaries { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<Equipment> Equipment { get; set; } = null!;
    public virtual DbSet<Farm> Farms { get; set; } = null!;
    public virtual DbSet<Fertilizer> Fertilizers { get; set; } = null!;
    public virtual DbSet<Field> Fields { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<Seedling> Seedlings { get; set; } = null!;
    public virtual DbSet<Subtask> Subtasks { get; set; } = null!;
    public virtual DbSet<Task> Tasks { get; set; } = null!;
    public virtual DbSet<Timekeeping> Timekeepings { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;
    public virtual DbSet<WarehouseProduct> WarehouseProducts { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=FarmManagementSystem;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cost>(entity =>
        {
            entity.ToTable("Cost");

            entity.Property(e => e.CostId).HasColumnName("CostID");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.Property(e => e.CostAmount).HasColumnType("decimal(11, 0)");

            entity.Property(e => e.CostDate).HasColumnType("date");

            entity.Property(e => e.CostDescription).HasMaxLength(500);

            entity.Property(e => e.CostName).HasMaxLength(50);

            entity.Property(e => e.Coststatus).HasColumnName("coststatus");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.HasOne(d => d.Category)
               .WithMany(p => p.Costs)
               .HasForeignKey(d => d.CategoryId)
               .HasConstraintName("FK_Cost_CostCategory");

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Costs)
               .HasForeignKey(d => d.FarmId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Cost_Farm");
        });

        modelBuilder.Entity<CostCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId)
               .HasName("PK__CostCate__19093A2BE15C114C");

            entity.ToTable("CostCategory");

            entity.Property(e => e.CategoryId)
               .ValueGeneratedNever()
               .HasColumnName("CategoryID");

            entity.Property(e => e.CategoryDescription).HasMaxLength(100);

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Diary>(entity =>
        {
            entity.ToTable("Diary");

            entity.Property(e => e.DiaryId).HasColumnName("DiaryID");

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.Property(e => e.DiaryCategory).HasMaxLength(50);

            entity.Property(e => e.DiarySubject).HasMaxLength(50);

            entity.Property(e => e.EntryDate).HasColumnType("date");

            entity.Property(e => e.FieldId).HasColumnName("FieldID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Field)
               .WithMany(p => p.Diaries)
               .HasForeignKey(d => d.FieldId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Diary_Field");

            entity.HasOne(d => d.Product)
               .WithMany(p => p.Diaries)
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Diary_Product");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.Property(e => e.EmployeeAddress).HasMaxLength(100);

            entity.Property(e => e.EmployeeEmail).HasMaxLength(100);

            entity.Property(e => e.EmployeeName).HasMaxLength(100);

            entity.Property(e => e.EmployeePhone).HasMaxLength(20);

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.Property(e => e.Position)
               .HasMaxLength(50)
               .HasColumnName("position");

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Employees)
               .HasForeignKey(d => d.FarmId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Employee_Farm");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

            entity.Property(e => e.EquipmentName).HasMaxLength(100);

            entity.Property(e => e.EquipmentType).HasMaxLength(100);

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Equipment)
               .HasForeignKey(d => d.FarmId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Equipment_Farm");
        });

        modelBuilder.Entity<Farm>(entity =>
        {
            entity.ToTable("Farm");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.Property(e => e.FarmLocation).HasMaxLength(100);

            entity.Property(e => e.FarmName).HasMaxLength(100);
        });

        modelBuilder.Entity<Fertilizer>(entity =>
        {
            entity.ToTable("Fertilizer");

            entity.Property(e => e.FertilizerId).HasColumnName("FertilizerID");

            entity.Property(e => e.FertilizerImport).HasColumnType("date");

            entity.Property(e => e.FertilizerName).HasMaxLength(100);

            entity.Property(e => e.FertilizerType).HasMaxLength(100);

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Warehouse)
               .WithMany(p => p.Fertilizers)
               .HasForeignKey(d => d.WarehouseId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Fertilizer_Warehouse");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("Field");

            entity.Property(e => e.FieldId).HasColumnName("FieldID");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.Property(e => e.FieldName).HasMaxLength(100);

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Fields)
               .HasForeignKey(d => d.FarmId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Field_Farm");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.FieldId).HasColumnName("FieldID");

            entity.Property(e => e.HarvestDate).HasColumnType("date");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.Property(e => e.SowingDate).HasColumnType("date");

            entity.HasOne(d => d.Field)
               .WithMany(p => p.Products)
               .HasForeignKey(d => d.FieldId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Product_Field");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleDescription).HasMaxLength(50);

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Seedling>(entity =>
        {
            entity.ToTable("Seedling");

            entity.Property(e => e.SeedlingDescription).HasMaxLength(500);

            entity.Property(e => e.SeedlingName).HasMaxLength(50);

            entity.Property(e => e.SeedlingStart).HasColumnType("date");
        });

        modelBuilder.Entity<Subtask>(entity =>
        {
            entity.Property(e => e.SubTaskId).ValueGeneratedNever();

            entity.Property(e => e.SubtaskName)
               .HasMaxLength(255)
               .IsUnicode(false);

            entity.Property(e => e.Subtaskstatus).HasColumnName("subtaskstatus");

            entity.HasOne(d => d.Task)
               .WithMany(p => p.Subtasks)
               .HasForeignKey(d => d.TaskId)
               .HasConstraintName("FK__Subtasks__TaskId__625A9A57");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.Property(e => e.DuaDate).HasColumnType("date");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.Property(e => e.FieldId).HasColumnName("FieldID");

            entity.Property(e => e.TaskDate).HasColumnType("date");

            entity.Property(e => e.TaskDescription).HasMaxLength(500);

            entity.Property(e => e.TaskName).HasMaxLength(100);

            entity.Property(e => e.TaskStatus).HasMaxLength(50);

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Tasks)
               .HasForeignKey(d => d.FarmId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Task_Farm");

            entity.HasOne(d => d.Field)
               .WithMany(p => p.Tasks)
               .HasForeignKey(d => d.FieldId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Task_Field");
        });

        modelBuilder.Entity<Timekeeping>(entity =>
        {
            entity.ToTable("Timekeeping");

            entity.Property(e => e.TimekeepingId).HasColumnName("TimekeepingID");

            entity.Property(e => e.CheckIn).HasColumnType("datetime");

            entity.Property(e => e.CheckOut).HasColumnType("datetime");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.Property(e => e.TimekeepingDate).HasColumnType("date");

            entity.HasOne(d => d.Employee)
               .WithMany(p => p.Timekeepings)
               .HasForeignKey(d => d.EmployeeId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Timekeeping_Employee");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.UserName, "UC_User_Username")
               .IsUnique();

            entity.Property(e => e.Id).HasColumnName("UserID");

            entity.Property(e => e.Email)
               .HasMaxLength(100)
               .IsUnicode(false);

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.UserName)
               .HasMaxLength(50)
               .IsUnicode(false);

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Users)
               .HasForeignKey(d => d.FarmId)
               .HasConstraintName("FK_User_Farm");

            entity.HasOne(d => d.Role)
               .WithMany(p => p.Users)
               .HasForeignKey(d => d.RoleId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");

            entity.Property(e => e.WarehouseLocation).HasMaxLength(100);

            entity.Property(e => e.WarehouseName).HasMaxLength(100);

            entity.HasOne(d => d.Farm)
               .WithMany(p => p.Warehouses)
               .HasForeignKey(d => d.FarmId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Warehouse_Farm");
        });

        modelBuilder.Entity<WarehouseProduct>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseId, e.ProductId });

            entity.ToTable("WarehouseProduct");

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.Unit)
               .HasMaxLength(50)
               .IsUnicode(false);

            entity.HasOne(d => d.Product)
               .WithMany(p => p.WarehouseProducts)
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_WarehouseProduct_Product");

            entity.HasOne(d => d.Warehouse)
               .WithMany(p => p.WarehouseProducts)
               .HasForeignKey(d => d.WarehouseId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_WarehouseProduct_Warehouse");
        });

        // Seeding Fields
        var fields = new[]
        {
            (name: "Bud Hill Thịnh Sơn", location: "Quản lý toàn bộ Farm", area: 10, used: 5),
            (name: "Bud Hill Farm Văn Sơn", location: "Quản lý Farm Thịnh Sơn", area: 26, used: 12),
            (name: "Bud Hill Trù Sơn", location: "Quản lý Farm  Văn Sơn", area: 5, used: 5),
        };

        modelBuilder.Entity<Farm>().HasData(fields.Select((f, i) => new Farm
        {
            FarmId = i + 1,
            FarmName = f.name,
            FarmLocation = f.location,
            FarmArea = f.area,
            AreaUsed = f.used
        }));

        // Seeding Roles
        var roles = new[]
        {
            (name: "Admin", desc: "Quản lý toàn bộ Farm"),
            (name: "TS Manager", desc: "Quản lý Farm Thịnh Sơn"),
            (name: "VS Manager", desc: "Quản lý Farm  Văn Sơn"),
            (name: "TS Engineer", desc: "Kỹ thuật viên Thịnh Sơn"),
            (name: "VS Engineer", desc: "Kỹ thuật viên Văn Sơn"),
            (name: "Worker", desc: "Công nhân farm")
        };

        modelBuilder.Entity<Role>().HasData(roles.Select((r, i) => new Role
        {
            Id = i + 1,
            Name = r.name,
            NormalizedName = r.name.ToUpper(),
            RoleDescription = r.desc
        }));

        // Seeding Users
        var users = new[]
        {
            (userName: "minhhiep", firstName: "Hiệp", lastName: "Thái Minh", email: "thaiminhhiep2311@gmail.com",
                roleId: 1, farmId: 1),
            (userName: "minhncbk", firstName: "Minh", lastName: "Nguyễn Công", email: "thaiminhhiep2311@gmail.com",
                roleId: 1, farmId: 1),
            (userName: "tuanthai", firstName: "Tuấn", lastName: "Thái", email: "tuanthai@gmail.com",
                roleId: 3, farmId: 2),
            (userName: "hoangtuan", firstName: "Tuấn", lastName: "Hoàng", email: "hoantuan@hacovina.vn",
                roleId: 2, farmId: 1),
            (userName: "conghai", firstName: "Hải", lastName: "Nguyễn Công", email: "conghaice@gmail.com",
                roleId: 1, farmId: 1)
        };

        modelBuilder.Entity<User>().HasData(users.Select((u, i) => new User
                {
                    Id = i + 1,
                    UserName = u.userName,
                    FirstName = u.firstName,
                    LastName = u.lastName,
                    NormalizedUserName = u.userName.ToUpper(),
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "123456"),
                    Email = u.email,
                    NormalizedEmail = u.email.ToUpper(),
                    RoleId = u.roleId,
                    FarmId = u.farmId,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            )
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}