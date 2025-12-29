namespace ERPAppDomain.Entities
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid? CreatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedById { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
