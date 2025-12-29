using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ERPAppContext _context;

        //Repositories registry (cache)
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ERPAppContext context)
        {
            _context = context;
        }
        //Generic Repository Access
        public IGenericRepository<T> Repository<T>() where T : class
        {
            return GetRepository<IGenericRepository<T>>(
                () => new GenericRepository<T>(_context));
        }
        //Specified Repositries
        public ICustomerRepository Customers
            => GetRepository<ICustomerRepository>(() => new CustomerRepository(_context));

        public IDepartmentRepository Departments
            => GetRepository<IDepartmentRepository>(() => new DepartmentRepository(_context));

        public IElectronicPaymentRepository ElectronicPayments
            => GetRepository<IElectronicPaymentRepository>(() => new ElectronicPaymentRepository(_context));

        public IEmployeeRepository Employees
            => GetRepository<IEmployeeRepository>(() => new EmployeeRepository(_context));

        public IInventoryTransactionRepository InventoryTransactions
            => GetRepository<IInventoryTransactionRepository>(() => new InventoryTransactionRepository(_context));

        public IOrderRepository Orders
            => GetRepository<IOrderRepository>(() => new OrderRepository(_context));

        public IOrderItemRepository OrderItems
            => GetRepository<IOrderItemRepository>(() => new OrderItemRepository(_context));

        public IPayrollRecordRepository PayrollRecords
            => GetRepository<IPayrollRecordRepository>(() => new PayrollRecordRepository(_context));

        public IPermissionRepository Permissions
            => GetRepository<IPermissionRepository>(() => new PermissionRepository(_context));

        public IProductRepository Products
            => GetRepository<IProductRepository>(() => new ProductRepository(_context));

        public IProductImageRepository ProductImages
            => GetRepository<IProductImageRepository>(() => new ProductImageRepository(_context));

        public IPurchaseOrderRepository PurchaseOrders
            => GetRepository<IPurchaseOrderRepository>(() => new PurchaseOrderRepository(_context));

        public IPurchaseOrderItemRepository PurchaseOrderItems
            => GetRepository<IPurchaseOrderItemRepository>(() => new PurchaseOrderItemRepository(_context));

        public IPurchasePaymentRepository PurchasePayments
            => GetRepository<IPurchasePaymentRepository>(() => new PurchasePaymentRepository(_context));

        public IRolePermissionRepository RolePermissions
            => GetRepository<IRolePermissionRepository>(() => new RolePermissionRepository(_context));

        public ISalePaymentRepository SalePayments
            => GetRepository<ISalePaymentRepository>(() => new SalePaymentRepository(_context));

        public ISupplierRepository Suppliers
            => GetRepository<ISupplierRepository>(() => new SupplierRepository(_context));

        public IWalletRepository Wallets
            => GetRepository<IWalletRepository>(() => new WalletRepository(_context));

        public IWalletTransactionRepository WalletTransactions
            => GetRepository<IWalletTransactionRepository>(() => new WalletTransactionRepository(_context));


        //Core Helpers

        private TRepo GetRepository<TRepo>(Func<TRepo> factory) where TRepo : notnull
        {
            var type = typeof(TRepo);

            if (!_repositories.TryGetValue(type,out var repo))
            {
                repo = factory();
                _repositories[type] = repo;
            }
            return (TRepo)repo;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction == null)
                await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
