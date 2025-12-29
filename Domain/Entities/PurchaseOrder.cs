namespace ERPAppDomain.Entities
{
    public class PurchaseOrder : AuditableEntity
    {
        public string Number { get; set; } = string.Empty;
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = default!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal TotalCost => SubTotal;
        public string Status { get; set; } = string.Empty;
        public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
        public ICollection<PurchasePayment> Payments { get; set; } = new List<PurchasePayment>();
    }
}
