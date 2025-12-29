using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>,IPermissionRepository
    {
        public PermissionRepository(ERPAppContext context) : base(context) { }
    }
}
