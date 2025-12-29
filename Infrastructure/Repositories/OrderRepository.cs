using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(ERPAppContext context) : base(context) { }
    }
}
