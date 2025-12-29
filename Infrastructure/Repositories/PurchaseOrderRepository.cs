using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>,IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ERPAppContext context) : base(context) { }
    }
}
