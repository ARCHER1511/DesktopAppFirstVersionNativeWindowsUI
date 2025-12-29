namespace ERPAppDomain.Entities
{
    public class ElectronicPayment : BaseEntity
    {
        public string ExternalTransactionId { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime OccurredAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
    }
}
