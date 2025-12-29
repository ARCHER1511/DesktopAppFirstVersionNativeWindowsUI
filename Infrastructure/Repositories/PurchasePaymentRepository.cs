using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class PurchasePaymentRepository : GenericRepository<PurchasePayment>,IPurchasePaymentRepository
    {
        public PurchasePaymentRepository(ERPAppContext context) : base(context) { }
    }
}
