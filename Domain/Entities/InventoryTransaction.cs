namespace ERPAppDomain.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public string TransactionType { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public DateTime TransactionAt { get; set; } = DateTime.Now;
        public Guid? RelatedEntityId { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
