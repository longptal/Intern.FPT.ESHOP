using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EShop.Models
{
    public partial class EShopContext : DbContext
    {
        public EShopContext()
        {
        }

        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryName> CategoryNames { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<Introduction> Introductions { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryCheckpoint> InventoryCheckpoints { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<IssueNote> IssueNotes { get; set; }
        public virtual DbSet<IssueNoteLine> IssueNoteLines { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleOperation> ModuleOperations { get; set; }
        public virtual DbSet<ModuleRole> ModuleRoles { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<Pack> Packs { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeName> ProductAttributeNames { get; set; }
        public virtual DbSet<ProductPicture> ProductPictures { get; set; }
        public virtual DbSet<ProductValue> ProductValues { get; set; }
        public virtual DbSet<ReceiptNote> ReceiptNotes { get; set; }
        public virtual DbSet<ReceiptNoteLine> ReceiptNoteLines { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<WareHouse> WareHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=10.4.24.60;initial catalog=EShop;persist security info=True;user id=sa;password=Thang4096@@!!;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Carrier");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Carrier")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Category");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Category")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<CategoryName>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CategoryName");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_CategoryName")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryNames)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryName_Category1");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CategoryNames)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryName_Language");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("City");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_City")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Country");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Country")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Coupon");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Coupon")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Customer");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Customer")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();

                entity.HasOne(d => d.CustomerGroup)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CustomerGroup");
            });

            modelBuilder.Entity<CustomerGroup>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CustomerGroup");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_CustomerGroup")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Discount");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Discount")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discount_Product");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Employee")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Display).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Input>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Input");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Input")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Inputs)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Input_Inventory");
            });

            modelBuilder.Entity<Introduction>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Introduction");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Introduction")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Inventory");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Inventory")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Product");

                entity.HasOne(d => d.WareHouse)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_WareHouse");
            });

            modelBuilder.Entity<InventoryCheckpoint>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("InventoryCheckpoint");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_InventoryCheckpoint")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryCheckpoints)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_InventoryCheckpoint_Inventory");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Invoice");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Invoice")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Order");
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("InvoiceLine");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_InvoiceLine")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLine_Invoice");
            });

            modelBuilder.Entity<IssueNote>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("IssueNote");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_IssueNote")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.IssueNotes)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueNote_Customer");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.IssueNotes)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueNote_Invoice");

                entity.HasOne(d => d.WareHouse)
                    .WithMany(p => p.IssueNotes)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueNote_WareHouse");
            });

            modelBuilder.Entity<IssueNoteLine>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("IssueNoteLine");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_IssueNoteLine")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.IssueNote)
                    .WithMany(p => p.IssueNoteLines)
                    .HasForeignKey(d => d.IssueNoteId)
                    .HasConstraintName("FK_IssueNoteLine_IssueNote");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.IssueNoteLines)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_IssueNoteLine_Product");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Language");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Language")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Icon).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Manufacturer");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Manufacturer")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Module");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Table_1")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ModuleOperation>(entity =>
            {
                entity.HasKey(e => new { e.OperationId, e.ModuleId });

                entity.ToTable("ModuleOperation");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleOperations)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModuleOperation_Module");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.ModuleOperations)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModuleOperation_Operation");
            });

            modelBuilder.Entity<ModuleRole>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.RoleId });

                entity.ToTable("ModuleRole");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleRoles)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModuleRole_Module");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ModuleRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModuleRole_Role");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Operation");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Operation")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Order");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Order")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Method).IsRequired();

                entity.Property(e => e.Total).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.ShipmentDetail)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipmentDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_ShipmentDetail");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("OrderDetail");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_OrderDetail")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Quantity).HasColumnType("numeric(38, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Pack)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Pack");
            });

            modelBuilder.Entity<Output>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Output");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Output")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Output_Inventory");
            });

            modelBuilder.Entity<Pack>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Pack");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Pack")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(20, 4)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Packs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pack_Product");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Permission");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Permission")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_Employee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_Role");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Product");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Product")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Unit).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Manufacturer");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ProductAttribute");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ProductAttribute")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttribute_Category");
            });

            modelBuilder.Entity<ProductAttributeName>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ProductAttributeName");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ProductAttributeName")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ProductAttributeNames)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttributeName_Language");

                entity.HasOne(d => d.ProductAttribute)
                    .WithMany(p => p.ProductAttributeNames)
                    .HasForeignKey(d => d.ProductAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttributeName_ProductAttribute");
            });

            modelBuilder.Entity<ProductPicture>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ProductPicture");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ProductPicture")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPicture_Product");
            });

            modelBuilder.Entity<ProductValue>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ProductValue");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ProductValue")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductValues)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductValue_ProductAttribute");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ProductValues)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductValue_Language");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductValues)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductValue_Product");
            });

            modelBuilder.Entity<ReceiptNote>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ReceiptNote");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ReceiptNote")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.SystemDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ReceiptNotes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptNote_Employee");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ReceiptNotes)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptNote_Supplier");

                entity.HasOne(d => d.WareHouse)
                    .WithMany(p => p.ReceiptNotes)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptNote_WareHouse");
            });

            modelBuilder.Entity<ReceiptNoteLine>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ReceiptNoteLine");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ReceiptNoteLine")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.ManufactureDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(20, 4)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ReceiptNoteLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptNoteLine_Product1");

                entity.HasOne(d => d.ReceiptNote)
                    .WithMany(p => p.ReceiptNoteLines)
                    .HasForeignKey(d => d.ReceiptNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptNoteLine_ReceiptNote");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Role");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Role")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ShipmentDetail>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ShipmentDetail");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_ShipmentDetail")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ShipmentDetails)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_ShipmentDetail_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ShipmentDetails)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_ShipmentDetail_Country");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShipmentDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentDetail_Customer");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Supplier");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Supplier")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.TaxCode).IsRequired();
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Tax");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Tax")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Percentage).HasColumnType("decimal(20, 4)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tax_Category");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tax_Country");
            });

            modelBuilder.Entity<WareHouse>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("WareHouse");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_WareHouse")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Stockkeeper)
                    .WithMany(p => p.WareHouses)
                    .HasForeignKey(d => d.StockkeeperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WareHouse_Employee");
            });
        }
    }
}
