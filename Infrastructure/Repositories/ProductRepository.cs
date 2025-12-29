using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ERPAppContext context) : base(context) { }
    }
}
