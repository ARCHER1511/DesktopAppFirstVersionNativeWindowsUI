namespace ERPAppDomain.Entities
{
    public class Employee : AuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
        public Guid? UserId { get; set; }
        public ApplicationUser User { get; set; } = default!;
        public ICollection<PayrollRecord> PayrollRecords { get; set; } = new List<PayrollRecord>();
    }
}
