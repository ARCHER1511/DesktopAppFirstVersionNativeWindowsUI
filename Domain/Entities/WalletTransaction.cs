namespace ERPAppDomain.Entities
{
    public class WalletTransaction : BaseEntity
    {
        public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; } = default!;
        public decimal Amount { get; set; }
        public DateTime At { get; set; } = DateTime.Now;
        public string type { get; set;} = string.Empty;
        public string Reference { get; set; } = string.Empty;
    }
}
