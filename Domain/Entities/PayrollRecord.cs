namespace ERPAppDomain.Entities
{
    public class PayrollRecord : AuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;
        public decimal GrossSalary { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary => GrossSalary - Deductions;
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime PaidAt { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
