namespace ERPAppDomain.Entities
{
    public abstract class PaymentBase : AuditableEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string Method { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
    }
}
