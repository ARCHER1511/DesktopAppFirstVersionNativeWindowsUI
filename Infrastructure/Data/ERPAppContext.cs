using ERPAppDomain.Entities;
using ERPAppInfrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ERPAppInfrastructure.Data
{
    public class ERPAppContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ERPAppContext(DbContextOptions<ERPAppContext> options) :base(options){}

        // ========================
        // Core Business Entities
        // ========================
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        // ========================
        // Orders & Sales
        // ========================
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SalePayment> SalePayments { get; set; }
        // ========================
        // Purchases
        // ========================
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<PurchasePayment> PurchasePayments { get; set; }
        // ========================
        // Inventory
        // ========================
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        // ========================
        // HR / Organization
        // ========================
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PayrollRecord> PayrollRecords { get; set; }
        // ========================
        // Security & Permissions
        // ========================
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        // ========================
        // Wallet & Finance
        // ========================
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<ElectronicPayment> ElectronicPayments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("ApplicationIdentity");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Apply your separate configurations
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleConfiguration());

            // Map the other Identity tables to the same schema
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "ApplicationIdentity");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "ApplicationIdentity");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "ApplicationIdentity");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "ApplicationIdentity");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "ApplicationIdentity");
        }

    }
}
