namespace ERPAppDomain.Entities
{
    public class PurchaseOrderItem : BaseEntity
    {
        public Guid PurchaseOrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public PurchaseOrder PurchaseOrder { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public decimal LineTotal => Quantity * CostPrice;
    }
}
