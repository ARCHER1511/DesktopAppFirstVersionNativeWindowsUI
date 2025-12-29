using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>,IProductImageRepository
    {
        public ProductImageRepository(ERPAppContext context) : base(context) { }
    }
}
