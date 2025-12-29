namespace ERPAppDomain.Entities
{
    public class Supplier : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ContractName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
        public ICollection<PurchasePayment> PurchasePayments { get; set; } = new List<PurchasePayment>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public bool IsActive { get; set; } = true;

    }
}
