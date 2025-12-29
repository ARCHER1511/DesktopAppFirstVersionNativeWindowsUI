namespace ERPAppDomain.Entities
{
    public class SalePayment : PaymentBase
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public Guid? ElectronicPaymentId { get; set; }
        public ElectronicPayment ElectronicPayment { get; set; } = default!;
    }
}
