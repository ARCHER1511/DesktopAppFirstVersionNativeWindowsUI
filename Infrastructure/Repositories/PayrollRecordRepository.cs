using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class PayrollRecordRepository : GenericRepository<PayrollRecord>,IPayrollRecordRepository
    {
        public PayrollRecordRepository(ERPAppContext context) : base(context) { }
    }
}
