using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Models; // Đổi namespace này nếu cần

namespace NMCNPM_Nhom7.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<CustomersModel> Customers { get; set; }
        public DbSet<ProductCategoryModel> ProductCategories { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<UnitModel> Units { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<DiscountedProductModel> DiscountedProducts { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<InvoiceDetailModel> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: set default schema/table names or composite keys here

            // Ví dụ: Giới hạn enum trạng thái "active"/"blocked" cho nhân viên (chỉ mapping, validation vẫn nên tự xử lý)
            modelBuilder.Entity<EmployeeModel>()
                .Property(e => e.SStatus)
                .HasDefaultValue("active");

            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e => e.IRole)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.IRoleID)
                .HasConstraintName("FK_Roles_iEmployeeID");

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.ICategoryID)
                .HasConstraintName("FK_Products_ProductCategories");

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Unit)
                .WithMany()
                .HasForeignKey(p => p.IUnitID)
                .HasConstraintName("FK_Units_iUnitID");

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.ISupplierID)
                .HasConstraintName("FK_Suppliers_iSupplierID");

            modelBuilder.Entity<DiscountedProductModel>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.IProductID)
                .HasConstraintName("FK_DiscountedProducts_Product");

            modelBuilder.Entity<InvoiceModel>()
                .HasOne(i => i.Employee)
                .WithMany()
                .HasForeignKey(i => i.IEmployeeID)
                .HasConstraintName("FK_Invoices_Employee");

            modelBuilder.Entity<InvoiceModel>()
                .HasOne(i => i.Customer)
                .WithMany()
                .HasForeignKey(i => i.ICustomerID)
                .HasConstraintName("FK_Invoices_Customers");

            modelBuilder.Entity<InvoiceDetailModel>()
                .HasOne(id => id.Invoice)
                .WithMany()
                .HasForeignKey(id => id.IInvoiceID)
                .HasConstraintName("FK_InvoiceDetail_Invoice");

            modelBuilder.Entity<InvoiceDetailModel>()
                .HasOne(id => id.Product)
                .WithMany()
                .HasForeignKey(id => id.IProductID)
                .HasConstraintName("FK_InvoiceDetail_Product");
        }
    }
}
