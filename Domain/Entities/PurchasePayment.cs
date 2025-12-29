namespace ERPAppDomain.Entities
{
    public class PurchasePayment : PaymentBase
    {
        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = default!;
        public Guid? SupplierId { get; set; }
        public Supplier Supplier { get; set; } = default!;
    }
}
