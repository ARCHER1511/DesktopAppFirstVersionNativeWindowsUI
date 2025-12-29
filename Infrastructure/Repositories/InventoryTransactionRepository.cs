using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class InventoryTransactionRepository : GenericRepository<InventoryTransaction>,IInventoryTransactionRepository
    {
        public InventoryTransactionRepository(ERPAppContext context) : base(context) { }
    }
}
