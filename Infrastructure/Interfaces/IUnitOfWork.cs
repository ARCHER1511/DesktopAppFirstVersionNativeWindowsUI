namespace ERPAppInfrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>()
            where T : class;
        Task<int> SaveChangesAsync();
        //Repos
        ICustomerRepository Customers { get;}
        IDepartmentRepository Departments { get;}
        IElectronicPaymentRepository ElectronicPayments { get;}
        IEmployeeRepository Employees { get;}
        IInventoryTransactionRepository InventoryTransactions { get;}
        IOrderRepository Orders { get;}
        IOrderItemRepository OrderItems { get;}
        IPayrollRecordRepository PayrollRecords { get;}
        IPermissionRepository Permissions { get;}
        IProductRepository Products { get;}
        IProductImageRepository ProductImages { get;}
        IPurchaseOrderRepository PurchaseOrders { get;}
        IPurchaseOrderItemRepository PurchaseOrderItems { get;}
        IPurchasePaymentRepository PurchasePayments { get;}
        IRolePermissionRepository RolePermissions { get;}
        ISalePaymentRepository SalePayments { get;}
        ISupplierRepository Suppliers { get;}
        IWalletRepository Wallets { get;}
        IWalletTransactionRepository WalletTransactions { get;}
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        new void Dispose();
    }
}
