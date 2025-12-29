namespace ERPAppDomain.Entities
{
    public class Product : AuditableEntity
    {
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int QuantityInStock { get; set; }
        public Guid? MainImageId { get; set; }
        public ProductImage MainImage { get; set; } = default!;
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public Guid? SupplierId { get; set; }
        public Supplier Supplier { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
    }
}
