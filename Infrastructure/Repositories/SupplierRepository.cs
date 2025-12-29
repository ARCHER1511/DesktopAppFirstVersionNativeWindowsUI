using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>,ISupplierRepository
    {
        public SupplierRepository(ERPAppContext context) : base(context) { }
    }
}
