namespace ERPAppDomain.Entities
{
    public class Customer : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? RecordedByUserId { get; set; }
        public ApplicationUser RecordedByUser { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
