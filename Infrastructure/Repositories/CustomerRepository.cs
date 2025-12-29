using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(ERPAppContext context) : base(context) { }
    }
}
