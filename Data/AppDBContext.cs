using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Models;

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
        public DbSet<ProductDetailModel> ProductDetails { get; set; }  // ✅ Bổ sung mới
        public DbSet<DiscountedProductModel> DiscountedProducts { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<InvoiceDetailModel> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>()
                .Property(e => e.SStatus)
                .HasDefaultValue("active");

            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e => e.IRole)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.IRoleID)
                .HasConstraintName("FK_Roles_iEmployeeID");

            // ProductModel → ProductCategory
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.ICategoryID)
                .HasConstraintName("FK_Products_ProductCategories");

            // ProductDetailModel → Product, Supplier, Unit
            modelBuilder.Entity<ProductDetailModel>()
                .HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(pd => pd.IProductID)
                .HasConstraintName("FK_ProductDetails_Products");

            modelBuilder.Entity<ProductDetailModel>()
                .HasOne(pd => pd.Supplier)
                .WithMany()
                .HasForeignKey(pd => pd.ISupplierID)
                .HasConstraintName("FK_ProductDetails_Suppliers");

            modelBuilder.Entity<ProductDetailModel>()
                .HasOne(pd => pd.Unit)
                .WithMany()
                .HasForeignKey(pd => pd.IUnitID)
                .HasConstraintName("FK_ProductDetails_Units");

            // Unique constraint (iProductID, iSupplierID, iUnitID)
            modelBuilder.Entity<ProductDetailModel>()
                .HasIndex(pd => new { pd.IProductID, pd.ISupplierID, pd.IUnitID })
                .IsUnique()
                .HasDatabaseName("UQ_ProductSupplierUnit");

            // DiscountedProduct → Product
            modelBuilder.Entity<DiscountedProductModel>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.IProductID)
                .HasConstraintName("FK_DiscountedProducts_Product");

            // Invoice → Employee
            modelBuilder.Entity<InvoiceModel>()
                .HasOne(i => i.Employee)
                .WithMany()
                .HasForeignKey(i => i.IEmployeeID)
                .HasConstraintName("FK_Invoices_Employee");

            // Invoice → Customer
            modelBuilder.Entity<InvoiceModel>()
                .HasOne(i => i.Customer)
                .WithMany()
                .HasForeignKey(i => i.ICustomerID)
                .HasConstraintName("FK_Invoices_Customers");

            // InvoiceDetail → Invoice
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
