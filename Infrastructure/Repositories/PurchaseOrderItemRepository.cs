using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class PurchaseOrderItemRepository : GenericRepository<PurchaseOrderItem>,IPurchaseOrderItemRepository
    {
        public PurchaseOrderItemRepository(ERPAppContext context) : base(context) { }
    }
}
