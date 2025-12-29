namespace ERPAppDomain.Entities
{
    public class Wallet : BaseEntity
    {
        public Guid OwnerUserId { get; set; }
        public decimal Balance { get; set; }
        public ICollection<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
    }
}
