namespace ERPAppDomain.Entities
{
    public class Order : AuditableEntity
    {
        public string Number { get; set; } = string.Empty;
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public Guid CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; } = default!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => SubTotal + Tax - Discount;
        public string Status { get; set; } = string.Empty;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public ICollection<SalePayment> Payments { get; set; } = new List<SalePayment>();
    }
}
