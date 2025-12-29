using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class RolePermissionRepository : GenericRepository<RolePermission>,IRolePermissionRepository
    {
        public RolePermissionRepository(ERPAppContext context) : base(context) { }
    }
}
