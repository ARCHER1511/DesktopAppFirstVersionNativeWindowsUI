using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class ElectronicPaymentRepository : GenericRepository<ElectronicPayment>,IElectronicPaymentRepository
    {
        public ElectronicPaymentRepository(ERPAppContext context) : base(context) { }
    }
}
