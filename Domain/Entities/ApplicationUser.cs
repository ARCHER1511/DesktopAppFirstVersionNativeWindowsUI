using Microsoft.AspNetCore.Identity;

namespace ERPAppDomain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
    }
}
