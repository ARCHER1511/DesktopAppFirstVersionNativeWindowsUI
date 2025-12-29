using Microsoft.AspNetCore.Identity;

namespace ERPAppDomain.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; } = string.Empty;
    }
}
