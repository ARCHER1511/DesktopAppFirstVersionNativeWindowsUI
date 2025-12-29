using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class SalePaymentRepository : GenericRepository<SalePayment>,ISalePaymentRepository
    {
        public SalePaymentRepository(ERPAppContext context) : base(context) { }
    }
}
