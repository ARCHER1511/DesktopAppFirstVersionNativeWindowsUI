using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;

namespace ERPAppInfrastructure.Repositories
{
    public class WalletTransactionRepository : GenericRepository<WalletTransaction>,IWalletTransactionRepository
    {
        public WalletTransactionRepository(ERPAppContext context) : base(context) { }
    }
}
