using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERPAppInfrastructure.Data
{
    public class ERPAppContextFactory : IDesignTimeDbContextFactory<ERPAppContext>
    {
        public ERPAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ERPAppContext>();

            optionsBuilder.UseSqlServer("Server=.;Database=ERPAppDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new ERPAppContext(optionsBuilder.Options);
        }
    }
}
